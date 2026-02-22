using System;
using UnityEngine;

/// <summary>
/// This is a class supposed to represent a battle entity, such as player or enemy bodyparts
/// might not be Monobehaviour, and interface/abstract class instead
/// </summary>
public abstract class BattleEntityController : MonoBehaviour
{
    [SerializeField, Range(1, byte.MaxValue)] private int maxHealth;

    public bool IsDefeated { get; private set; }

    public int CurrentHealth { get; private set; }
    
    public event Action<DamageTakenEventArgs> OnDamaged;
    public event Action<EffectAppliedEventArgs> OnEffectApplied;
    public event Action<BattleEntityController> OnDefeated;
    //etc...

    /// <summary>
    /// Method to take damage implemented via Template Method pattern
    /// </summary>
    /// <param name="damageInfo" type="DamageInfo">Information about taken damage</param>
    /// <returns></returns>
    public DamageTakenEventArgs TakeDamage(DamageInfo damageInfo)
    {
        if (IsDefeated)
        {
            LogTryingDamageDefeatedBattleEntity();
            return null;
        }
        
        var damageToStaminaReceived = 0;
        var isBodyPartElementBreak = false;
        
        int damageToHealthReceived = DecreaseHealth(damageInfo.DamageToHealth);
        bool isBodyPartDefeated = HandleDefeat();
        ApplyDamageConsequences(damageInfo,
            ref damageToStaminaReceived, ref isBodyPartElementBreak);
        
        DamageTakenEventArgs damageTakenEventArgs = 
            new DamageTakenEventArgs(
            damageInfo,
            damageToHealthReceived,
            damageToStaminaReceived,
            isBodyPartElementBreak,
            isBodyPartDefeated,
            
            false //may be implemented or removed in the future
        );
        OnDamaged?.Invoke(damageTakenEventArgs);
        return damageTakenEventArgs;
    }
    
    public abstract EffectAppliedEventArgs ApplyEffect();

    protected virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private int DecreaseHealth(int healthDecline)
    {
        if (healthDecline < 0) LogIncorrectHealthDecline(healthDecline);
        
        int healthBeforeTakenDamage = CurrentHealth;
        CurrentHealth = 
            Mathf.Clamp(CurrentHealth-healthDecline, 0, maxHealth);
        int receivedHealthDecline = healthBeforeTakenDamage - CurrentHealth;
        
        return receivedHealthDecline;
    }
    

    private bool HandleDefeat()
    {
        if (CurrentHealth != 0) return false;
        
        IsDefeated = true;
        
        OnDefeated?.Invoke(this);
        
        OnDamaged = null;
        OnEffectApplied = null;
        OnDefeated = null;
        
        return true;
    }

    protected abstract void ApplyDamageConsequences
        (DamageInfo damageInfo,ref int damageToStaminaReceived, ref bool isBodyPartElementBreak);
    
    
    private void LogIncorrectHealthDecline(int healthDecline) =>
        Debug.LogWarning($"Taking negative ({healthDecline}) damage to health of {gameObject.name}");
    
    private void LogTryingDamageDefeatedBattleEntity() =>
        Debug.LogWarning($"Trying to take damage to defeated {gameObject.name}");
    
}