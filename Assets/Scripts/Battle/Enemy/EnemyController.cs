using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public IReadOnlyList<EnemyBodyPartController> BodyParts => bodyParts;
    public event Action<EnemyController> OnDead;
    
    [SerializeField] private List<EnemyBodyPartController> bodyParts;
    
    
    private void BodyPartDie(BattleEntityController bodyPart)
    {
        if (bodyPart.IsVital)
            Die();
    }

    private void Start()
    {
        foreach (EnemyBodyPartController bodyPart in bodyParts)
        {
            bodyPart.OnDefeated += BodyPartDie;
        }
    }
    
    private void Die()
    {
        OnDead?.Invoke(this);
        OnDead = null;
    }
    

    #region Validation
    public void OnValidate()
    {
        if (bodyParts == null || bodyParts.Count == 0) return;
        RemoveDuplicates();
    }

    private void RemoveDuplicates()
    {
        HashSet<EnemyBodyPartController> uniqueParts = new();
        var wasChanged = false;

        for (var i = 0; i < bodyParts.Count; i++)
        {
            EnemyBodyPartController partController = bodyParts[i];

            if (partController == null) continue;
            if (uniqueParts.Add(partController)) continue;
            
            LogDuplicateBodyPart(partController);
            bodyParts[i] = null;
            wasChanged = true;
        }

        if (wasChanged)
            RemoveNullEntries();
    }

    private void RemoveNullEntries()
    {
        bodyParts = (List<EnemyBodyPartController>)
            from bodyPart in bodyParts where bodyPart != null select bodyPart;
    }

    private void LogDuplicateBodyPart(EnemyBodyPartController partController) =>
        Debug.LogWarning(
            $"Duplicate body part '{partController.name}' was removed from the list on object {gameObject.name}",
            gameObject);
    #endregion
}