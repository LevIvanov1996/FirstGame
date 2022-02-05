using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject barrier;
   
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeSpawnBar;
    [SerializeField] private int spawnCountToEnemyCreation;
    public static int PostEnemy;
    private int summ;
    private int barrierSpawnCount;
    private float nextspawn;
    public int namberBorder1;
    public int namberBorder2;
    public int bigger => namberBorder1 > namberBorder2 ? namberBorder1 : namberBorder2;

    private void FixedUpdate()
    {
        if (CanSpawn())
        {
            summ = summ + bigger;
            PostEnemy = summ;
           
            if (barrierSpawnCount == spawnCountToEnemyCreation)
            {
                Spawn(enemy);
                barrierSpawnCount = 0;
                
                Debug.Log("сумма чисел енеми "+summ);

            }
            else
            {
                Spawn(barrier);
                barrierSpawnCount++;
                namberBorder1 = Barier.text1;
                namberBorder2 = Barier.text2;   
                Debug.Log("большее из чисел"+bigger);
                
            }
        }
    }
    private bool CanSpawn() => Time.time >= nextspawn;
    private void Spawn(GameObject obj)
    {
        nextspawn = Time.time + timeSpawnBar;
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
