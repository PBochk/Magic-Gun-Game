using UnityEngine;

public sealed class TestAttackBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestAttackBodyPartActionService();
}