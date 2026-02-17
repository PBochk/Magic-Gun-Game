namespace cardgameinterfaces;


/// <summary>
/// This is a class supposed to represent a battle entity, such as player or enemy bodyparts
/// might not be Monobehaviour, and interface/abstract class instead
/// </summary>
public abstract class BattleEntity : Monobehaviour
{
    public bool isPlayer;
    //this can just be empty for player, i don't think we need separate class for that
    public abstract IReadOnlyList<BodyPartTag> BodyPartTags { get; }
    public abstract IReadOnlyList<BattleEntity> AllBodyParts { get; }
    public abstract int CurrentHp { get; }
    
    public event Action<DamageEventFeedback> Damage;
    public event Action<EffectAppliedEventFeedback> EffectApplied;
    public event Action Death;
    //etc...

    public abstract DamageEventFeedback TakeDamage(DamageInfo damageInfo);
    public abstract DamageEventFeedback ApplyEffect();
}