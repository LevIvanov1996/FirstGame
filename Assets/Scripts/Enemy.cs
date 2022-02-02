using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static TextMesh textEnemy;
    public static int texen;
    private Vector2 _downVect;
    public float Speed=3f;
    
  

    void Start()
    {
        texen = int.Parse(textEnemy.text);
    }

    
    void Update()
    {
       
        _downVect = new Vector2(0, Speed);
        transform.Translate(_downVect);
    }
}
