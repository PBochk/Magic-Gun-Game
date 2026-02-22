using UnityEngine;

public sealed class TestVitalBodyPartController : EnemyBodyPartController
{
    protected override BodyPartActionService ActionService => actionService ??=
        new TestVitalBodyPartActionService();
}