using JetBrains.Annotations;
using UnityEngine;

public abstract class EnemyBodyPartController : BattleEntityController
{
    public bool IsVital => isVital;

    public int CurrentStamina => currentStamina ??= maxStamina;

    [SerializeField, Range(1, byte.MaxValue)] private int maxStamina;
    [SerializeField] private EnemyBodyPartTags tags;
    [SerializeField] private bool isVital;

    protected virtual BodyPartActionService ActionService { get; set; }
    [CanBeNull] protected BodyPartActionService actionService;

    private bool WasNotBrokenThisTurn => !wasBrokenThisTurn;
    private bool wasBrokenThisTurn;

    private int? currentStamina;

    public void ExecuteAction()
    {
        ActionService.GetAction().Execute();
    }
    
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
    
    
    private int DecreaseStamina(int staminaDecline)
    {
        if (staminaDecline < 0) LogIncorrectStaminaDecline();
        
        int staminaBeforeTakenDamage = CurrentHealth;
        currentStamina = 
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