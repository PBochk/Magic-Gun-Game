public abstract class EnemyBodyPartController : BattleEntityController
{
    public override DamageTakenEventArgs TakeDamage(DamageInfo damageInfo)
    {
        throw new System.NotImplementedException();
    }

    public override EffectAppliedEventArgs ApplyEffect()
    {
        throw new System.NotImplementedException();
    }
}