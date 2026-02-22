using System;
using UnityEngine;

public sealed class TestVitalBodyPartActionService : BodyPartActionService
{
    protected override EnemyBodyPartAction ChooseAction()
    {
        return EnemyBodyPartAction.CreateEmpty();
    }
}
