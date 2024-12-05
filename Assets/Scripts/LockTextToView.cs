using UnityEngine;

public class LockTextToView : MonoBehaviour
{
    public Transform vrCamera;
    //bloquear la rotación del texto
    void LateUpdate()
    {
        transform.position = vrCamera.position + vrCamera.forward * 2.0f;
        transform.rotation = Quaternion.Euler(0, vrCamera.eulerAngles.y, 0);
    }
}
