using UnityEngine;

public class ExamplesBarrier : MonoBehaviour
{
    [SerializeField] private TextMesh _exaple1;
    [SerializeField] private TextMesh _exaple2;

    private void Awake()
    {
        //������������� ������ �������
        _exaple1.text = GeneratNumber().ToString();
        _exaple2.text = GeneratNumber().ToString();
    }
    private void FixedUpdate()
    {
        // �������� �������
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
    // �������� ���������� �����
    private int GeneratNumber() => (int)Random.Range(1f, 20f);
}
