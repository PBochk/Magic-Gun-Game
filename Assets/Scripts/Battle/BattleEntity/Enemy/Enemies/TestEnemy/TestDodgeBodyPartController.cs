using UnityEngine;

public sealed class TestDodgeBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestDodgeBodyPartActionService();
}