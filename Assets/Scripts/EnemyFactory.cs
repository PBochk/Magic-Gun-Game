using UnityEngine;
using Zenject;

public sealed class EnemyFactory : IFactory<Object, EnemyController>
{
    private readonly DiContainer container;

    public EnemyFactory(DiContainer container)
    {
        this.container = container;
    }

    public EnemyController Create(Object prefab)
    {
        return container.InstantiatePrefabForComponent<EnemyController>(prefab);
    }
}