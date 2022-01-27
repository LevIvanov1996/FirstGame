using UnityEngine;

public class Example : MonoBehaviour
{
    private void  OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }
}
