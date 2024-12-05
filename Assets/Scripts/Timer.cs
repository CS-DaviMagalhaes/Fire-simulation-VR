using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // texto del timer
    public TextMeshProUGUI gameOverText; // texto de game Over

    [HideInInspector]
    public float timeLeft = 10; // Tiempo maximo de simulación

    void Update()
    {
        if (timeLeft < 1) // Si el tiempo termina
        {
            timerText.text = "";
            gameOverText.text = "No pasaste la simulación";
        }
        else
        {
            timeLeft -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            timerText.text = $"Tiempo restante: {minutes:00}:{seconds:00}";
        }
    }
}
