using UnityEngine;

public class BarcoController : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        // Move apenas no eixo X (horizontal)
        transform.Translate(new Vector2(h, 0f) * speed * Time.deltaTime);
    }
}
