using UnityEngine;
using UnityEngine.UI;

public class AlarmHandler : MonoBehaviour
{
    public AudioSource alarmSound;  // Asignar el Audio Source aquí.
    public float delay = 20f;       // Tiempo de espera antes de sonar.

    public Button startButton;      // Asigna el botón de "Start".
    public GameObject textToHide;   // Asigna el texto que se debe ocultar.
    public Transform camera;        // Asigna la cámara (OVRCameraRig u otra).
    public Vector3 newCameraPosition; // Nueva posición a donde mover la cámara.

    public void StartAlarm()
    {
        // Ocultar el botón y texto inmediatamente
        if (startButton != null)
        {
            startButton.gameObject.SetActive(false);
        }

        if (textToHide != null)
        {
            textToHide.SetActive(false);
        }

        // Iniciar el retraso para el sonido y movimiento de cámara
        Invoke("PlayAlarm", delay);
    }

    private void PlayAlarm()
    {
        // Mover la cámara justo antes de sonar la alarma
        if (camera != null)
        {
            camera.position = newCameraPosition; // Cambia la posición de la cámara.
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
