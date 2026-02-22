using UnityEngine;

public sealed class TestAttackBodyPartActionService : BodyPartActionService
{
    protected override EnemyBodyPartAction ChooseAction()
    {
        return EnemyBodyPartAction.Create(null, "Атака", () => Debug.Log("Атака!!!"));
    }
}
