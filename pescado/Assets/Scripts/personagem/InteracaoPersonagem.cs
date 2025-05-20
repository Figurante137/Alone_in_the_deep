using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private string currentZone = "";
    private bool isPiloting = false;
    private bool isFishing = false;

    public GameObject barco; // Atribuir via Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentZone == "Mastro" && !isPiloting)
            {
                StartPiloting();
            }
            else if (currentZone == "AreaDePesca" && !isFishing)
            {
                StartFishing();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllActions();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Mastro"))
        {
            currentZone = "Mastro";
        }
        else if (other.gameObject.name.Contains("AreaDePesca"))
        {
            currentZone = "AreaDePesca";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentZone = "";
    }

    void StartPiloting()
    {
        isPiloting = true;
        // desativa controle do personagem
        GetComponent<MovimentoPersonagem>().enabled = false;
        // agora o personagem move o barco
        barco.GetComponent<BarcoController>().enabled = true;
    }

    void StartFishing()
    {
        isFishing = true;
        GetComponent<MovimentoPersonagem>().enabled = false;
    }

    void StopAllActions()
    {
        isPiloting = false;
        isFishing = false;
        GetComponent<MovimentoPersonagem>().enabled = true;
        if (barco != null) barco.GetComponent<BarcoController>().enabled = false;
        Debug.Log("Parou todas as ações");
    }
}
