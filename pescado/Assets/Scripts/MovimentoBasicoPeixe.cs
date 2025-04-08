using UnityEngine;

public class MovimentoBasicoPeixe : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 3f;
    public float swimAmplitude = 0.5f;
    public float swimFrequency = 2f;

    private Vector2 direction;
    private float timer;
    private Vector2 startPos;

    void Start()
    {
        ChooseNewDirection();
        startPos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Muda a direção após um tempo
        if (timer >= changeDirectionTime)
        {
            ChooseNewDirection();
            timer = 0;
        }

        // Movimento oscilante
        Vector2 swimOffset = new Vector2(0, Mathf.Sin(Time.time * swimFrequency) * swimAmplitude);
        transform.Translate((direction * speed * Time.deltaTime) + swimOffset * Time.deltaTime);

        // Aqui você pode adicionar detecção de borda da tela para mudar direção
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
