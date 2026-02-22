using System;
using UnityEngine;

/// <summary>
/// This is a class supposed to represent a battle entity, such as player or enemy bodyparts
/// might not be Monobehaviour, and interface/abstract class instead
/// </summary>
public abstract class BattleEntityController : MonoBehaviour
{
    [field:SerializeField] public int MaxHealth { get; private  set; }

    public int CurrentHealth { get; private set; }
    
    public event Action<DamageTakenEventArgs> OnDamaged;
    public event Action<EffectAppliedEventArgs> OnEffectApplied;
    public event Action<BattleEntityController> OnDead;
    //etc...

    /// <summary>
    /// Method to take damage implemented via Template Method pattern
    /// </summary>
    /// <param name="damageInfo" type="DamageInfo">Information about taken damage</param>
    /// <returns></returns>
    public DamageTakenEventArgs TakeDamage(DamageInfo damageInfo)
    {
        var damageToStaminaReceived = 0;
        var isBodyPartElementBreak = false;
        
        int damageToHealthReceived = DecreaseHealth(damageInfo.DamageToHealth);
        bool isBodyPartDefeated = HandleDefeat();
        ApplyDamageConsequences(damageInfo,
            ref damageToStaminaReceived, ref isBodyPartElementBreak);
        
        return new DamageTakenEventArgs(
            damageInfo,
            damageToHealthReceived,
            damageToStaminaReceived,
            isBodyPartElementBreak,
            isBodyPartDefeated,
            false
            );
    }
    
    public abstract EffectAppliedEventArgs ApplyEffect();

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private int DecreaseHealth(int healthDecline)
    {
        if (healthDecline < 0) LogIncorrectHealthDecline();
        
        int healthBeforeTakenDamage = CurrentHealth;
        CurrentHealth = 
            Mathf.Clamp(CurrentHealth-healthDecline, 0, MaxHealth);
        int receivedHealthDecline = healthBeforeTakenDamage - CurrentHealth;
        return receivedHealthDecline;
    }
    

    private bool HandleDefeat()
    {
        if (CurrentHealth != 0) return false;
        
        OnDead?.Invoke(this);
        
        OnDamaged = null;
        OnEffectApplied = null;
        OnDead = null;
        
        return true;
    }

    protected abstract void ApplyDamageConsequences
        (DamageInfo damageInfo,ref int damageToStaminaReceived, ref bool isBodyPartElementBreak);
    
    
    private static void LogIncorrectHealthDecline() =>
        Debug.LogWarning("Taking damage to health is negative");
}