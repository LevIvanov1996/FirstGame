using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private TextMesh _textMesh;
    private Vector2 _delta;
    
    void FixedUpdate()
    {
        // �������� ������ (� ������������� �� ����� ������)
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
        // ��������� ������������ � ������� ���������.
        // ���������� �������� ���� text ������� � ������� �� �����������.
        int collObjectScore = int.Parse(coll.gameObject.GetComponentInChildren<TextMesh>().text);

        // ���� ��� ������ ������� ��������� ��������� ����� � ������.
        if(coll.gameObject.tag == "CheckBarrier")
        {
            // ���� ���������� ����� � ������ ������ ��� ����� ���������� ����� ������� � ������� �� ��������������� (�������).
            if (_score >= collObjectScore)
            {
                // ������ �������� � ������ ���������� ����� ������� � ������� �� ����������.
                _score -= collObjectScore;
            }
            else
            {
                // � ��������� ������ ����� ������������, ���� ���������������.
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }
        else // ����� ������ ������ 
        {
            // ����������� ���� �������, ������.
            _score += collObjectScore;
        }
        // ���������� ������ � ������� ���������������� �����.
        Destroy(coll.gameObject);
        // ������ � TextMesh ����� �������� ����� ������.
        _textMesh.text = _score.ToString();
    }
    private void OnTriggerEnter2D (Collider2D coll)
    {
        // ����������������� �������� ����� ������ (��������� ��������).
        _textMesh.text = coll.gameObject.name == "Danger" ? (--_score).ToString() : _score.ToString();
    }
    private void Move() => transform.Translate(_delta * _moveSpeed);
}
