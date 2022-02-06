using UnityEngine;

namespace Assets.Scripts
{
    internal class Falling : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.1f;

        private void FixedUpdate() => Fall();
        private void Fall() => transform.Translate(new Vector2(0, -_speed));
    }
}
