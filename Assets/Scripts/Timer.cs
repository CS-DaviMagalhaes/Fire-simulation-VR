using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer text
    public TextMeshProUGUI gameOverText; // Game over text
    public Image blackPanel; // Panel para oscurecer la pantalla

    private float maxSimulationTime = 200f;
    private float passOutTime; //Cuando el jugador empieza a "desmayarse"
    public float timeLeft;

    private void Start()
    {

        timeLeft = maxSimulationTime;
        passOutTime = maxSimulationTime * 0.3f; // el x% del tiempo restante la pantalla se va a oscurecer 

        // Panel transparente inicialmente
        if (blackPanel != null)
        {
            blackPanel.color = new Color(0, 0, 0, 0);
        }
    }

    private void Update()
    {
        // Ver si hay tiempo disponible
        if (timeLeft <= 0)
        {
            timerText.text = "";
            gameOverText.text = "No pasaste la simulación";

            // Pantalla completamente negra cuando termina el tiempo
            if (blackPanel != null)
            {
                blackPanel.color = new Color(0, 0, 0, 1);
            }
        }
        else
        {
            //Reducir tiempo resetante
            timeLeft -= Time.deltaTime;

            // Actualizar texto timer
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            timerText.text = $"Tiempo restante: {minutes:00}:{seconds:00}";

            // Comienza a desmayarse (oscurecer la pantalla )
            if (timeLeft < passOutTime && blackPanel != null)
            {
                float alpha = 1 - Mathf.Clamp01(timeLeft / passOutTime);
                blackPanel.color = new Color(0, 0, 0, alpha);
            }
        }
    }
}
