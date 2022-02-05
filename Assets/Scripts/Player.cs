using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    private Vector2 _moveDelta;
    public TextMesh scoreCube;
    
    public int Score;
   
    

     void Start()
    {
       
    }
    void FixedUpdate()
    {
      
        scoreCube.text = Score.ToString();
        float x = Input.GetAxis("Horizontal");
        _moveDelta = new Vector2(x, 0);

        if (transform.position.x <= -8.34f)
        {
            transform.Translate(new Vector2(16.50f, 0f));
        }
        else if (transform.localPosition.x >= 8.34f)
        {
              transform.Translate(new Vector2(-16.50f, 0f));
            
        }
        else
        {
            transform.Translate(_moveDelta * Time.deltaTime * 6);
        }
    }

    public void Move()
    {
        transform.Translate(_moveDelta * Time.deltaTime * 6);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Score = Score + Int32.Parse(coll.gameObject.GetComponentInChildren<TextMesh>().text);
        scoreCube.text = Score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Danger")
        {
            Score--;
            scoreCube.text = Score.ToString();
        }
    }
}
