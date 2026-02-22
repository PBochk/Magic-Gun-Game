using UnityEngine;

public sealed class TestAttackBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestAttackBodyPartActionService();
    
    private sealed class TestAttackBodyPartActionService : BodyPartActionService
    {
        protected override EnemyBodyPartAction ChooseAction()
        {
            return EnemyBodyPartAction.Create(null, "Атака", () => Debug.Log("Атака!!!"));
        }
    }
}