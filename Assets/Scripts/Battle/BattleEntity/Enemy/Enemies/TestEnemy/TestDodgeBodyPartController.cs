using UnityEngine;

public sealed class TestDodgeBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestDodgeBodyPartActionService();
    
    private sealed class TestDodgeBodyPartActionService : BodyPartActionService
    {
        protected override EnemyBodyPartAction ChooseAction()
        {
            return EnemyBodyPartAction.Create(null, "Уклонение", () => Debug.Log("Уклонение ~~"));
        }
    }

}