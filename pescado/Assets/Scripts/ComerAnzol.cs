using UnityEngine;
using UnityEngine.UI;

public class ComerAnzol : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Anzol"))
        {
            // Chama o minigame
            StartMinigame();
            // Desativa o Movimrnto do peixe
            this.GetComponent<MovimentoBasicoPeixe>().enabled = false;
        }
    }
    [Header("UI")]
    public GameObject minigameUI;
    public RectTransform pointer; // Ponteiro que gira
    public float pointerSpeed = 180f; // graus por segundo

    [Header("Zona verde")]
    public float greenZoneStartAngle = 45f;
    public float greenZoneEndAngle = 90f;

    [Header("Vida do peixe")]
    public Slider fishHealthBar; // Slider para mostrar vida
    public float fishMaxHealth = 100f;
    private float currentFishHealth;
    public float damagePerHit = 20f; // Quanto de vida perde a cada acerto

    private bool isPlaying = false;

    void Start()
    {
        minigameUI.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying) return;

        // Gira o ponteiro
        pointer.Rotate(Vector3.forward, -pointerSpeed * Time.deltaTime);

        // Input para checar o acerto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }

    public void StartMinigame()
    {
        isPlaying = true;
        minigameUI.SetActive(true);

        // Reseta ângulo e vida do peixe
        pointer.rotation = Quaternion.Euler(0, 0, 0);
        currentFishHealth = fishMaxHealth;
        UpdateHealthBar();
    }

    void CheckSuccess()
    {
        float angle = pointer.eulerAngles.z;
        if (angle < 0) angle += 360f;

        if (angle >= greenZoneStartAngle && angle <= greenZoneEndAngle)
        {
            Debug.Log("Acertou! Peixe perde vida.");
            currentFishHealth -= damagePerHit;
            UpdateHealthBar();

            if (currentFishHealth <= 0)
            {
                Debug.Log("Peixe pescado!");
                EndMinigame(true);
            }
        }
        else
        {
            Debug.Log("Errou! O peixe escapou.");
            EndMinigame(false);
        }
    }

    void UpdateHealthBar()
    {
        if (fishHealthBar != null)
        {
            fishHealthBar.value = currentFishHealth / fishMaxHealth;
        }
    }

    void EndMinigame(bool success)
    {
        isPlaying = false;
        minigameUI.SetActive(false);

        if (success)
        {
            //Adicionar o peixe ao inventário ou algo assim
        }
        else
        {
            //Reativa o peixe ou remove ele, Me falta criatividade meu Deus o intel n sei das quantas ta tentando prever o que eu vou COMENTARRRRR  
        }
    }
}
