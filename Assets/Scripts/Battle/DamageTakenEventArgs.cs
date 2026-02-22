using System;

public sealed class DamageTakenEventArgs : EventArgs
 {
     public DamageInfo DamageInfo { get; }
     public int DamageToHealthReceived { get; }
     public int DamageToStaminaReceived { get; }
     public bool IsBodyPartElementBreak { get; }
     public bool IsBodyPartDefeated { get; }
     public bool WasKilled { get; }
     //...etc, can be extended
     
     public DamageTakenEventArgs(
         DamageInfo damageInfo,
         int damageToHealthReceived,
         int damageToStaminaReceived,
         bool isBodyPartElementBreak,
         bool isBodyPartDefeated,
         bool wasKilled)
     {
         DamageInfo = damageInfo;
         DamageToHealthReceived = damageToHealthReceived;
         DamageToStaminaReceived = damageToStaminaReceived;
         IsBodyPartElementBreak = isBodyPartElementBreak;
         IsBodyPartDefeated = isBodyPartDefeated;
         WasKilled = wasKilled;
     }
 }
