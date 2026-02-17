namespace cardgameinterfaces;

[Flags]
public enum BodyPartTag
{
    None = 0,
    Head = 1 << 1,
    Torso = 1 << 2,
    Arm = 1 << 3,
    Leg = 1 << 4,
    Upper = 1 << 5,
    Lower = 1 << 6
        //...etc, this is just an example
}