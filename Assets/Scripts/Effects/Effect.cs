using System;

/// <summary>
/// This class is supposed to represent example of effects realisation, such as 'burn' 'vital' etc
/// </summary>
public abstract class Effect
{
    public int Amount { get; }
    public EffectType Type { get; }
    public BattleEntity Source { get; }
    //another possible fields in derivatives like damage

    public event Action OnApplied;
    public event Action OnTurnStarted;
    public event Action OnTurnEnded;
    //...etc
}