using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform cameraTransform; // Arrastra la cámara principal aquí
    public Vector3 newCameraPosition; // Define la nueva posición

    public void MoveCamera()
    {
        Debug.Log("Cambiando posición de la cámara...");
        if (cameraTransform != null)
        {
            cameraTransform.position = newCameraPosition;
        }
    }
}
