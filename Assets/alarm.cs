using UnityEngine;
using UnityEngine.UI;

public class AlarmHandler : MonoBehaviour
{
    public AudioSource alarmSound;  // Asignar el Audio Source aqu�.
    public float delay = 20f;       // Tiempo de espera antes de sonar.

    public Button startButton;      // Asigna el bot�n de "Start".
    public GameObject textToHide;   // Asigna el texto que se debe ocultar.
    public Transform camera;        // Asigna la c�mara (OVRCameraRig u otra).
    public Vector3 newCameraPosition; // Nueva posici�n a donde mover la c�mara.

    public void StartAlarm()
    {
        // Ocultar el bot�n y texto inmediatamente
        if (startButton != null)
        {
            startButton.gameObject.SetActive(false);
        }

        if (textToHide != null)
        {
            textToHide.SetActive(false);
        }

        // Iniciar el retraso para el sonido y movimiento de c�mara
        Invoke("PlayAlarm", delay);
    }

    private void PlayAlarm()
    {
        // Mover la c�mara justo antes de sonar la alarma
        if (camera != null)
        {
            camera.position = newCameraPosition; // Cambia la posici�n de la c�mara.
        }

        // Reproducir el sonido de alarma
        if (alarmSound != null)
        {
            alarmSound.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado un Audio Source.");
        }
    }
}
