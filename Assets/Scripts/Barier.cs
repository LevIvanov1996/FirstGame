using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{
    private Vector2 _downVect;
    public float Speed;
    public TextMesh Example1;
    public TextMesh Example2;

    void Start()
    {
        Example1.text = GeneratNumber().ToString();
        Example2.text = GeneratNumber().ToString();
    }
    void FixedUpdate()
    {
        Fall();
        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }
    private static int GeneratNumber() => (int)Random.Range(1f, 20f);

    private void Fall()
    {
        _downVect = new Vector2(0, Speed);
        transform.Translate(_downVect);
    }
}
