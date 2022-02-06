using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private TextMesh _textMesh;
    private Vector2 _delta;
    
    void FixedUpdate()
    {
        // Движение игрока (с ограничениями по краям экрана)
        _delta = new Vector2(Input.GetAxis("Horizontal"), 0);

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
            Move();
        }
    }
    private void OnCollisionEnter2D (Collision2D coll)
    {
        // Обработка столкновений с другими объектами.
        // Запоминаем значение поля text объекта с которым мы столкнулись.
        int collObjectScore = int.Parse(coll.gameObject.GetComponentInChildren<TextMesh>().text);

        // Если это барьер который проверяет количесто очков у игрока.
        if(coll.gameObject.tag == "CheckBarrier")
        {
            // Если количество очков у игрока больше или равно количеству очков объекта с которым он взаимодействует (колизия).
            if (_score >= collObjectScore)
            {
                // Просто отнимаем у игрока количество очков объекта с которым он сталкнулся.
                _score -= collObjectScore;
            }
            else
            {
                // В противном случае игрок уничтожается, игра останавливается.
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }
        else // Любой другой объект 
        {
            // Присваеваем очки объекта, игроку.
            _score += collObjectScore;
        }
        // Уничтожаем объект с которым взаимодействовал игрок.
        Destroy(coll.gameObject);
        // Выводи в TextMesh новое значение очков игрока.
        _textMesh.text = _score.ToString();
    }
    private void OnTriggerEnter2D (Collider2D coll)
    {
        // Декриментирование значение очков игрока (Тернарный оператор).
        _textMesh.text = coll.gameObject.name == "Danger" ? (--_score).ToString() : _score.ToString();
    }
    private void Move() => transform.Translate(_delta * _moveSpeed);
}
