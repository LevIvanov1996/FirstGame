using UnityEngine;

namespace Assets.Scripts.TestsScripts
{
    internal class DevastatingCollisionTest : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (gameObject.transform.parent != null)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
