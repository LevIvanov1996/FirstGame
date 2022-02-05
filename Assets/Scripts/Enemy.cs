using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  TextMesh textEnemy;
    private Vector2 _downVect;
    public float Speed=3f;
    
  

    void Start()
    {
       textEnemy.text  = Spawner.PostEnemy.ToString();
    }

    
    void Update()
    {
       
        _downVect = new Vector2(0, Speed);
        transform.Translate(_downVect);
    }
}
