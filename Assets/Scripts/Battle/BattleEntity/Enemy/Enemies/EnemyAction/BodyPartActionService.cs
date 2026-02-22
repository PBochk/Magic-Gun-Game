public abstract class BodyPartActionService
{
    public EnemyBodyPartAction GetAction()
    {
        return ChooseAction();
    }

    protected abstract EnemyBodyPartAction ChooseAction();

}