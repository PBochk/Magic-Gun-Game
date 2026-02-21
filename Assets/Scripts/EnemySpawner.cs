using UnityEngine;
using Zenject;

public sealed class EnemySpawner
{
    private readonly IFactory<Object, EnemyController> factory;

    public EnemySpawner(IFactory<Object, EnemyController> factory)
    {
        this.factory = factory;
    }

    public EnemyController SpawnEnemy(Object prefab)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Creating enemy prefab is null");
            return null;
        }
        
        return factory.Create(prefab);
    }
}