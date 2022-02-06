using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _examplesBarrier;
    [SerializeField] private GameObject _checkBarrier;
    [SerializeField] private float _spawnDelayDuration;
    [SerializeField] private int _spawnCountToCheckBarrierCreation;
    [SerializeField] private int _sum;
    private int _barrierSpawnCount;
    private float _nextSpawn;

    private void Start() => SpawnExamplesBarrier();
    private void FixedUpdate()
    {
        // Если можно создавать новый объект.
        if (CanSpawn())
        {
            // И количесто уже созданых барьеров равняется количеству необходимому для создания барьера проверяющего очки игрока.
            if (_barrierSpawnCount == _spawnCountToCheckBarrierCreation)
            {
                // Получаем ссылку на этот барьер.
                var temp = Spawn(_checkBarrier);
                // Присвоили значение поля _sum (максимальное значение во всех созданых барьерах).
                temp.GetComponentInChildren<TextMesh>().text = _sum.ToString();
                // Обнулили значения счетчика созданых барьеров и предидущую сумму очков.
                _barrierSpawnCount = 0;
                _sum = 0;
            }
            else
            {
                // Тогда просто воздаем барьер с примерами.
                SpawnExamplesBarrier();
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Возвращает true если мы можем создать новый объект на сцене.</returns>
    private bool CanSpawn() => Time.time >= _nextSpawn;
    /// <summary>
    /// Создает барьер с примерами.
    /// </summary>
    private void SpawnExamplesBarrier()
    {
        // Получаем ссылку на созданный на сцене объект.
        var temp = Spawn(_examplesBarrier);
        // Получаем значение примеров в этом объекте.
        int example1Value = int.Parse(temp.transform.GetChild(0).GetComponentInChildren<TextMesh>().text);
        int example2Value = int.Parse(temp.transform.GetChild(1).GetComponentInChildren<TextMesh>().text);
        // Присваевает наибольшее значение в поле _sum (Тернарный оператор).
        _sum += example1Value > example2Value ? example1Value : example2Value;
        // Обновляем количество созданых объектов.
        _barrierSpawnCount++;
    }
    /// <summary>
    /// Создеёт передаваемый в параметрах GameObject.
    /// </summary>
    private GameObject Spawn(GameObject obj)
    {
        _nextSpawn = Time.time + _spawnDelayDuration;
        return Instantiate(obj, transform.position, Quaternion.identity);
    }
}
