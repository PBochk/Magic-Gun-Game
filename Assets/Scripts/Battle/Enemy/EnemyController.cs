using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public IReadOnlyList<EnemyBodyPartController> BodyParts => bodyParts;

    [SerializeField] private EnemyBodyPartController[] bodyParts;

    #region Validation
    public void OnValidate()
    {
        if (bodyParts == null || bodyParts.Length == 0) return;
        RemoveDuplicates();
    }

    private void RemoveDuplicates()
    {
        HashSet<EnemyBodyPartController> uniqueParts = new();
        var wasChanged = false;

        for (var i = 0; i < bodyParts.Length; i++)
        {
            EnemyBodyPartController partController = bodyParts[i];

            if (partController == null) continue;
            if (uniqueParts.Add(partController)) continue;
            
            LogDuplicateBodyPart(partController);
            bodyParts[i] = null;
            wasChanged = true;
        }

        if (wasChanged)
            RemoveNullEntries();;
    }

    private void RemoveNullEntries() =>
        bodyParts = bodyParts.Where(p => p != null).ToArray();

    private void LogDuplicateBodyPart(EnemyBodyPartController partController) =>
        Debug.LogWarning(
            $"Duplicate body part '{partController.name}' was removed from the list on object {gameObject.name}",
            gameObject);
    #endregion
}