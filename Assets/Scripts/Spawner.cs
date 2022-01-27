using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeSpawnBar;
    [SerializeField] private int spawnCountToEnemyCreation;
    private int barrierSpawnCount;
    private float nextspawn;
    private Vector2 spawn;
   

    private void Start()
    {
        spawn = new Vector2(transform.position.x, transform.position.y);
       
    }
    private void FixedUpdate()
    {
        if(CanSpawn())
        {
            if(barrierSpawnCount == spawnCountToEnemyCreation)
            {
                Spawn(enemy);
                barrierSpawnCount = 0;
            }
            else
            {
                Spawn(barrier);
                barrierSpawnCount++;
            }
        }

    }
    private bool CanSpawn() => Time.time >= nextspawn;
   
    private void Spawn(GameObject obj)
    {
        nextspawn = Time.time + timeSpawnBar;
        Instantiate(obj, spawn, Quaternion.identity);
    }
}
