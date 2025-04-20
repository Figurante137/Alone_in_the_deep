using UnityEngine;

public class MovimentoBasicoPeixe : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 3f;
    public float swimAmplitude = 0.5f;
    public float swimFrequency = 2f;
    public float rayDistance = 1f;
    public LayerMask limite;

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, limite);
        if (hit.collider != null)
        {
            //ChooseNewDirection(); // Muda a direção se bateu em um limite
            direction = direction * -1;
            ChooseNewDirection();
            timer = 0f;
        }
        // Muda a direção após um tempo
        if (timer >= changeDirectionTime)
        {
            ChooseNewDirection();
            timer = 0f;
        }

        // Movimento oscilante
        Vector2 swimOffset = new Vector2(0, Mathf.Sin(Time.time * swimFrequency) * swimAmplitude);
        transform.Translate((direction * speed * Time.deltaTime) + swimOffset * Time.deltaTime);
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
    void OnDrawGizmos()
    {
        // Gizmo para visualizar o Raycast na cena
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * rayDistance));
    }
}
