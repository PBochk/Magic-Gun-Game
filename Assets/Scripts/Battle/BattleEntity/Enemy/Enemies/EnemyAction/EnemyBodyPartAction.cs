using System;
using UnityEngine;

public class EnemyBodyPartAction
{
    public static EnemyBodyPartAction Create(Sprite intentSprite, string description, Action action)
    {
        return new(intentSprite, description, action);
    }
    
    public static EnemyBodyPartAction CreateEmpty()
    {
        return new(null, null, null);
    }
    
    private EnemyBodyPartAction(Sprite intentSprite, string description, Action action)
    {
        IntentSprite = intentSprite;
        Description = description;
        this.action = action;
    }

    public Sprite IntentSprite { get; }
    public string Description { get; } //TODO: change to localization
    public void Execute() => action?.Invoke();
    
    private readonly Action action;
}