using System.Collections.Generic;
using UnityEngine;

public class BattleHandlerTest : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<GameObject> _splitedPlayer;
    [SerializeField] private List<GameObject> _splitedEnemy;
    [SerializeField] private float _splitScale = 0.5f;
    [SerializeField] private float _force = 0.5f;

    private void Start()
    {
        TextMesh _playerTextMash = _player.GetComponentInChildren<TextMesh>();
        TextMesh _enemyTextMash = _enemy.GetComponentInChildren<TextMesh>();

        _player.SetActive(false);

        int newPlayersCount = int.Parse(_playerTextMash.text);
        _playerTextMash.text = "1";
        _splitedPlayer = SplitObject(_player, newPlayersCount, _splitScale);
        Destroy(_player);

        int newEnemiesCount = int.Parse(_enemyTextMash.text);
        _enemyTextMash.text = "1";
        _splitedEnemy = SplitObject(_enemy, newEnemiesCount, _splitScale);
        Destroy(_enemy);
    }
    private List<GameObject> SplitObject(GameObject obj, int newObjectsCount, float scale)
    {
        List<GameObject> newObjectsList = new List<GameObject>(newObjectsCount);
        obj.transform.localScale 
            = new Vector2(scale * obj.transform.localScale.x, scale * obj.transform.localScale.y);
        for (int i = 0; i < newObjectsCount; i++)
        {
            newObjectsList.Add(Instantiate(obj));
        }
        Destroy(obj);

        return newObjectsList;
    }
}   
