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
        if (!RemoveDuplicates()) return;

        RemoveNullEntries();
    }

    private bool RemoveDuplicates()
    {
        HashSet<EnemyBodyPart> uniqueParts = new();
        return MarkDuplicateEntries(uniqueParts);
    }

    private bool MarkDuplicateEntries(HashSet<EnemyBodyPart> uniqueParts)
    {
        var duplicatesFound = false;

        for (var i = 0; i < bodyParts.Length; i++)
        {
            EnemyBodyPart part = bodyParts[i];

            if (part == null || uniqueParts.Add(part)) continue;

            LogDuplicateBodyPart(part);
            bodyParts[i] = null;
            duplicatesFound = true;
        }

        return duplicatesFound;
    }

    private void RemoveNullEntries() =>
        bodyParts = bodyParts.Where(p => p != null).ToArray();

    private void LogDuplicateBodyPart(EnemyBodyPart part) =>
        Debug.LogWarning(
            $"Duplicate body part '{part.name}' was removed from the list on object {gameObject.name}",
            gameObject);
    #endregion
}
