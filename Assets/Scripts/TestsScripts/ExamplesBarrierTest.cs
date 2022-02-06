using UnityEngine;

public class ExamplesBarrierTest : MonoBehaviour
{
    [SerializeField] private TextMesh _exaple1;
    [SerializeField] private TextMesh _exaple2;

    void Start()
    {
        _exaple1.text = GeneratNumber().ToString();
        _exaple2.text = GeneratNumber().ToString();
    }
    private int GeneratNumber() => (int)Random.Range(1f, 20f);
}
