using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject barrier;
   
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeSpawnBar;
    [SerializeField] private int spawnCountToEnemyCreation;
    private int barrierSpawnCount;
    private float nextspawn;
    private Vector2 spawn;

   
    public int namberBorder1;
    public  int namberBorder2;
    public int bigger;
    public void Start()
    {
      
      
        spawn = new Vector2(transform.position.x, transform.position.y);

    }
    private void FixedUpdate()
    {
       
        if (CanSpawn())
        {
            if(barrierSpawnCount == spawnCountToEnemyCreation)
            {
                Spawn(enemy);
                barrierSpawnCount = 0;
                Debug.Log(Enemy.texen);

            }
            else
            {
                Spawn(barrier);
                barrierSpawnCount++;
                namberBorder1 = Barier.text1;
                namberBorder2 = Barier.text2;
                WhoIsBigger();
                Debug.Log(bigger);
                
            }
        }


        Enemy.textEnemy.text += bigger.ToString();
    }
  

   
    public void WhoIsBigger()
    {
        if (namberBorder1 >= namberBorder2)
        {
            bigger = namberBorder1;
        }
        else
        {
            bigger = namberBorder2;
        }
       
        
    }
   
    private bool CanSpawn() => Time.time >= nextspawn;
   
    private void Spawn(GameObject obj)
    {
        nextspawn = Time.time + timeSpawnBar;
        Instantiate(obj, spawn, Quaternion.identity);
    }
}
