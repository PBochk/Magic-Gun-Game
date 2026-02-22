using UnityEngine;

public abstract class EnemyBodyPartController : BattleEntityController
{
    public bool IsVital => isVital;

    public int CurrentStamina { get; private set; }

    [SerializeField, Range(1, byte.MaxValue)] private int maxStamina;
    [SerializeField] private EnemyBodyPartTags tags;
    [SerializeField] private bool isVital;
    private bool WasNotBrokenThisTurn => !wasBrokenThisTurn;
    private bool wasBrokenThisTurn;
    
    public override EffectAppliedEventArgs ApplyEffect()
    {
        throw new System.NotImplementedException();
    }

    protected sealed override void ApplyDamageConsequences
        (DamageInfo damageInfo, ref int damageToStaminaReceived, ref bool isBodyPartElementBreak)
    {
        damageToStaminaReceived = DecreaseStamina(damageInfo.DamageToStamina);
        isBodyPartElementBreak = HandleBroke();
    }

    protected override void Awake()
    {
        base.Awake();
        CurrentStamina = maxStamina;
    }
    
    private int DecreaseStamina(int staminaDecline)
    {
        if (staminaDecline < 0) LogIncorrectStaminaDecline();
        
        int staminaBeforeTakenDamage = CurrentHealth;
        CurrentStamina = 
            Mathf.Clamp(CurrentStamina-staminaDecline, 0, maxStamina);
        int receivedStaminaDecline = staminaBeforeTakenDamage - CurrentStamina;
        return receivedStaminaDecline;
    }
    
    private bool HandleBroke()
    {
        if (WasNotBrokenThisTurn || CurrentStamina != 0) return false;
        wasBrokenThisTurn = true;
        return true;
    }
    
    private static void LogIncorrectStaminaDecline() =>
        Debug.LogWarning("Taking damage to stamina is negative");
}