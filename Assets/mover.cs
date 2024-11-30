using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;          // Referencia al botón "Start"
    public GameObject fireSimulationText;   // Referencia al texto "FIRE SIMULATION"
    public AudioSource audioSource1;        // Primer AudioSource para el primer sonido
    public AudioSource audioSource2;        // Segundo AudioSource para el segundo sonido

    public void HideUI()
    {
        // Ocultar el botón "Start"
        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        // Ocultar el texto "FIRE SIMULATION"
        if (fireSimulationText != null)
        {
            fireSimulationText.SetActive(false);
        }

        // Reproducir el primer sonido
        if (audioSource1 != null)
        {
            audioSource1.Play();
        }

        // Reproducir el segundo sonido
        if (audioSource2 != null)
        {
            audioSource2.Play();
        }
    }
}
