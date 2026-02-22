using Zenject;
using Object = UnityEngine.Object;

public class DemoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindEnemyFactory();
        BindEnemySpawner();
    }

    private void BindEnemySpawner()
    {
        Container
            .Bind<EnemySpawner>()
            .AsSingle();
    }

    private void BindEnemyFactory()
    {
        Container
            .Bind<IFactory<Object, EnemyController>>()
            .To<EnemyFactory>()
            .AsSingle()
            .WhenInjectedInto<EnemySpawner>();
    }
}
