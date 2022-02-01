using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 _downVect;
    public float Speed=10f;
    public TextMesh textEnemy;

    void Start()
    {
        
    }

    
    void Update()
    {
        _downVect = new Vector2(0, Speed);
        transform.Translate(_downVect);
    }
}
