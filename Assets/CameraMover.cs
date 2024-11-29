using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform cameraTransform; // Arrastra la c�mara principal aqu�
    public Vector3 newCameraPosition; // Define la nueva posici�n

    public void MoveCamera()
    {
        Debug.Log("Cambiando posici�n de la c�mara...");
        if (cameraTransform != null)
        {
            cameraTransform.position = newCameraPosition;
        }
    }
}
