namespace cardgameinterfaces;

public struct DamageEventFeedback
{
    public DamageInfo damageInfo;
    public int damageReceived;
    public int hpDamageReceived;
    public bool bodyPartElementBreak;
    public bool bodyPartDefeated;
    public bool wasKilled;
    //...etc, can be extended
}