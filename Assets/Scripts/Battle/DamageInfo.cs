public readonly struct DamageInfo
{
    public BattleEntityController Source { get; }
    public int DamageToHealth { get; }
    public int DamageToStamina { get; }
    public Element Element { get; }
}