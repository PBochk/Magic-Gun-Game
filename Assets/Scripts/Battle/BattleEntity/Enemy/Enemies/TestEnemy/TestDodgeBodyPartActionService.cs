using System;
using UnityEngine;

public sealed class TestDodgeBodyPartActionService : BodyPartActionService
{
    protected override EnemyBodyPartAction ChooseAction()
    {
        return EnemyBodyPartAction.Create(null, "Уклонение", () => Debug.Log("Уклонение ~~"));
    }
}
