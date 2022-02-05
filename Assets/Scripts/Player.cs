using UnityEngine;

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
        
        int collObjectScore = int.Parse(coll.gameObject.GetComponentInChildren<TextMesh>().text);
        Score = Score + collObjectScore;
        scoreCube.text = Score.ToString();

        if(coll.gameObject.name=="Enemy")
        {

            if (Score >= collObjectScore)
            {
                Score -= collObjectScore;
            }
            else
                Destroy(gameObject);
            Destroy(coll.gameObject);
        }
        scoreCube.text = Score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Danger")
        {
            Score--;
            scoreCube.text = Score.ToString();
        }
        scoreCube.text = Score.ToString();
    }
}
