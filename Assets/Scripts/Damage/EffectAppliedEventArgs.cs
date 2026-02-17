using System;

public sealed class EffectAppliedEventArgs : EventArgs
{
    public bool IsSuccessful { get; }
    public Effect Effect { get; }
        //...etc
}