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
        // ���� ����� ��������� ����� ������.
        if (CanSpawn())
        {
            // � ��������� ��� �������� �������� ��������� ���������� ������������ ��� �������� ������� ������������ ���� ������.
            if (_barrierSpawnCount == _spawnCountToCheckBarrierCreation)
            {
                // �������� ������ �� ���� ������.
                var temp = Spawn(_checkBarrier);
                // ��������� �������� ���� _sum (������������ �������� �� ���� �������� ��������).
                temp.GetComponentInChildren<TextMesh>().text = _sum.ToString();
                // �������� �������� �������� �������� �������� � ���������� ����� �����.
                _barrierSpawnCount = 0;
                _sum = 0;
            }
            else
            {
                // ����� ������ ������� ������ � ���������.
                SpawnExamplesBarrier();
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>���������� true ���� �� ����� ������� ����� ������ �� �����.</returns>
    private bool CanSpawn() => Time.time >= _nextSpawn;
    /// <summary>
    /// ������� ������ � ���������.
    /// </summary>
    private void SpawnExamplesBarrier()
    {
        // �������� ������ �� ��������� �� ����� ������.
        var temp = Spawn(_examplesBarrier);
        // �������� �������� �������� � ���� �������.
        int example1Value = int.Parse(temp.transform.GetChild(0).GetComponentInChildren<TextMesh>().text);
        int example2Value = int.Parse(temp.transform.GetChild(1).GetComponentInChildren<TextMesh>().text);
        // ����������� ���������� �������� � ���� _sum (��������� ��������).
        _sum += example1Value > example2Value ? example1Value : example2Value;
        // ��������� ���������� �������� ��������.
        _barrierSpawnCount++;
    }
    /// <summary>
    /// ������ ������������ � ���������� GameObject.
    /// </summary>
    private GameObject Spawn(GameObject obj)
    {
        _nextSpawn = Time.time + _spawnDelayDuration;
        return Instantiate(obj, transform.position, Quaternion.identity);
    }
}
