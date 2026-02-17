namespace cardgameinterfaces;

/// <summary>
/// This class is supposed to represent example of effects realisation, such as 'burn' 'vital' etc
/// </summary>
public abstract class Effect
{
    public readonly int amount;
    public readonly EffectType type;
    public readonly BattleEntity source;
    //another possible fields in derivatives like damage

    public event Action OnApply;
    public event Action OnTurnStart;
    public event Action OnTurnEnd;
    //...etc
    
}