using UnityEngine;

namespace Assets.Scripts
{
    internal class SpawnerTest : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnTarget;
        [SerializeField] private float _spawnDelayDuration = 5.0f;
        private float _nextSpawn;

        private void Start()
        {
            Spawn(_spawnTarget);
        }
        private void FixedUpdate()
        {
            if (CanSpawn())
            {
                Spawn(_spawnTarget);
            }
        }
        private bool CanSpawn() => Time.time >= _nextSpawn;
        private void Spawn(GameObject obj)
        {
            _nextSpawn = Time.time + _spawnDelayDuration;
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }
}
