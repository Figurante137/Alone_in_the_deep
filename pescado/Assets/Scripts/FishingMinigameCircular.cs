using UnityEngine;
using UnityEngine.UI;

public class FishingMinigameCircular : MonoBehaviour
{
    [Header("UI")]
    public GameObject minigameUI;
    public RectTransform pointer; // ponteiro girando
    public float pointerSpeed = 180f; // graus por segundo

    [Header("Zona verde (em graus)")]
    public float greenZoneStartAngle = 30f;
    public float greenZoneEndAngle = 90f;

    [Header("Vida do peixe")]
    public float fishMaxHealth = 3f;
    public float damagePerHit = 1f;
    private float currentFishHealth;

    private bool isPlaying = false;

    void Start()
    {
        minigameUI.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying) return;

        // Rotação contínua do ponteiro
        pointer.Rotate(Vector3.forward, -pointerSpeed * Time.deltaTime);

        // Quando o jogador aperta espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }

    public void StartMinigame()
    {
        isPlaying = true;
        minigameUI.SetActive(true);

        // Reinicia ponteiro e vida do peixe
        pointer.rotation = Quaternion.Euler(0, 0, 0);
        currentFishHealth = fishMaxHealth;
        //cOMENTARIO muito importante se não o codigo não funciona
    }

    void CheckSuccess()
    {
        float angle = pointer.eulerAngles.z;
        if (angle < 0) angle += 360f;

        if (angle >= greenZoneStartAngle && angle <= greenZoneEndAngle)
        {
            // Acertou!
            Debug.Log("Acertou!");
            currentFishHealth -= damagePerHit;

            if (currentFishHealth <= 0)
            {
                EndMinigame(true);
            }
        }
        else
        {
            Debug.Log("Errou! O peixe escapou!");
            EndMinigame(false);
        }
    }

    void EndMinigame(bool success)
    {
        isPlaying = false;
        minigameUI.SetActive(false);

        if (success)
        {
            
        }
        else
        {
            
        }
    }
}
