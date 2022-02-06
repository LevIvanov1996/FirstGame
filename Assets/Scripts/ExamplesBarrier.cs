using UnityEngine;

public class ExamplesBarrier : MonoBehaviour
{
    [SerializeField] private TextMesh _exaple1;
    [SerializeField] private TextMesh _exaple2;

    private void Awake()
    {
        //Инициализация нового барьера
        _exaple1.text = GeneratNumber().ToString();
        _exaple2.text = GeneratNumber().ToString();
    }
    private void FixedUpdate()
    {
        // Удаление барьера
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
    // Созлание рандомного числа
    private int GeneratNumber() => (int)Random.Range(1f, 20f);
}
