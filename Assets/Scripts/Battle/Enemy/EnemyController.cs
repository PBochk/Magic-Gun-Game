using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public IReadOnlyList<EnemyBodyPart> BodyParts => bodyParts;

    [SerializeField] private EnemyBodyPart[] bodyParts;

    #region Validation
    public void OnValidate()
    {
        if (bodyParts == null || bodyParts.Length == 0) return;
        RemoveDuplicates();
    }

    private void RemoveDuplicates()
    {
        HashSet<EnemyBodyPart> uniqueParts = new();
        var wasChanged = false;

        for (var i = 0; i < bodyParts.Length; i++)
        {
            EnemyBodyPart part = bodyParts[i];

            if (part == null) continue;
            if (uniqueParts.Add(part)) continue;
            
            LogDuplicateBodyPart(part);
            bodyParts[i] = null;
            wasChanged = true;
        }

        if (wasChanged)
            RemoveNullEntries();;
    }

    private void RemoveNullEntries() =>
        bodyParts = bodyParts.Where(p => p != null).ToArray();

    private void LogDuplicateBodyPart(EnemyBodyPart part) =>
        Debug.LogWarning(
            $"Duplicate body part '{part.name}' was removed from the list on object {gameObject.name}",
            gameObject);
    #endregion
}