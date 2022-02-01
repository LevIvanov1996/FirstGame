using UnityEngine;
using System;
public class Example : MonoBehaviour
{
   
    private void  OnCollisionEnter2D(Collision2D coll)

    {
      
        Destroy(gameObject);
    }
}
