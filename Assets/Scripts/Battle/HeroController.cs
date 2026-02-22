public sealed class HeroController : BattleEntityController
{
    public override EffectAppliedEventArgs ApplyEffect()
    {
        throw new System.NotImplementedException();
    }
    
    protected override void ApplyDamageConsequences
        (DamageInfo damageInfo, ref int damageToStaminaReceived, ref bool isBodyPartElementBreak) {}
}
