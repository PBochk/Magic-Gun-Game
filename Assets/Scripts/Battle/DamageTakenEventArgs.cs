using System;

public sealed class DamageTakenEventArgs : EventArgs
 {
    public DamageInfo DamageInfo { get; }
    public int DamageReceived { get; }
    public int HealthDamageReceived { get; }
    public bool IsBodyPartElementBreak { get; }
    public bool IsBodyPartDefeated { get; }
    public bool WasKilled { get; }
        //...etc, can be extended
 }