using UnityEngine;
using Zenject;

//This class is for demo purpose only
public class GameInitializerForDemoOnly : MonoBehaviour
{
    [SerializeField] private EnemyController testEnemy;
    private EnemySpawner spawner;

    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        this.spawner = spawner;
    }
    
    private void Start()
    {
        spawner.SpawnEnemy(testEnemy);
    }
}
