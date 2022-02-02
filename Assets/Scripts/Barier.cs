using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{
    public TextMesh Exaple1;
    public TextMesh Exaple2;
    public static int text1;
    public static int text2;
    private Vector2 _downVect;
    public float Speed;


    void Start()
    {
        Exaple1.text = GeneratNumber().ToString();
        Exaple2.text = GeneratNumber().ToString();
        text1 = int.Parse(Exaple1.text);
        text2 = int.Parse(Exaple2.text);
    }

    public int GeneratNumber() => (int)Random.Range(1f, 20f);
    void FixedUpdate()
    {
        Fall();
        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }

   

    private void Fall()
    {
        _downVect = new Vector2(0, Speed);
        transform.Translate(_downVect);
    }
}
