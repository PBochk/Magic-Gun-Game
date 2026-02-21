using System;
using UnityEngine;

/// <summary>
/// This is a class supposed to represent a battle entity, such as player or enemy bodyparts
/// might not be Monobehaviour, and interface/abstract class instead
/// </summary>
public abstract class BattleEntity : MonoBehaviour
{
    public int CurrentHealth { get; protected set; }
    
    public event Action<DamageTakenEventArgs> OnDamaged;
    public event Action<EffectAppliedEventArgs> OnEffectApplied;
    public event Action OnDead;
    //etc...

    public abstract DamageTakenEventArgs TakeDamage(DamageInfo damageInfo);
    public abstract EffectAppliedEventArgs ApplyEffect();
}