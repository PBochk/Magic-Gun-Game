using UnityEngine;

public sealed class TestVitalBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestVitalBodyPartActionService();
    
    private sealed class TestVitalBodyPartActionService : BodyPartActionService
    {
        protected override EnemyBodyPartAction ChooseAction()
        {
            return EnemyBodyPartAction.CreateEmpty();
        }
    }

}