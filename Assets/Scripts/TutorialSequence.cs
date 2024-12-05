using UnityEngine;
using UnityEngine.XR;

public class TutorialSequence : MonoBehaviour
{
    public GameObject fireExtinguisher; // Asignar el extintor en el editor
    public GameObject exitDoor; // Asignar la puerta de salida en el editor
    public TMPro.TextMeshProUGUI tutorialText; // Campo para mostrar el texto del tutorial
    public bool fireExtinguished; // Esta variable será actualizada por otro script

    private bool hasLookedAround = false;
    private bool hasMovedAround = false;
    private bool hasGrabbedExtinguisher = false;
    private bool hasUsedExtinguisher = false;
    private bool hasExitedBuilding = false;

    private float movementTime = 0f; // Para verificar si el usuario ha movido por lo menos por un tiempo
    private const float requiredTime = 1.8f;  // tiempo para validar que ha usado el input suficiente

    private XRNode leftHand = XRNode.LeftHand;
    private XRNode rightHand = XRNode.RightHand;

    private void Start()
    {
        ShowTutorialText("Mira a tu alrededor con el joystick izquierdo");
    }

    private void Update()
    {
        if (!hasLookedAround)
        {
            if (CheckLeftJoystickMovement())
            {
                hasLookedAround = true;
                movementTime = 0f;
                ShowTutorialText("Camina con eljoystick izquierdo");
            }
        }
        else if (!hasMovedAround)
        {
            if (CheckLeftJoystickMovement())
            {
                hasMovedAround = true;
                movementTime = 0f; 
                ShowTutorialText("Agarra el extintor utilizando el trigger izquierdo secundario");
            }
        }
        else if (!hasGrabbedExtinguisher)
        {
            if (CheckGrabbedObject())
            {
                hasGrabbedExtinguisher = true;
                movementTime = 0f; 
                ShowTutorialText("Usa el extintor presionando el trigger principal derecho");
            }
        }
        else if (!hasUsedExtinguisher)
        {
            if (CheckUsedExtinguisher())
            {
                hasUsedExtinguisher = true;
                ShowTutorialText("Intenta apagar el fuego");
            }
        }
        else if (!fireExtinguished)
        {
            if (fireExtinguished)
            {
                ShowTutorialText("Encuentra la salida del edificio. Guíate de las señales de emergencia");
            }
        }
        else if (!hasExitedBuilding)
        {
            if (CheckExitedBuilding())
            {
                hasExitedBuilding = true;
                ShowTutorialText("Felicidades, has completado el tutorial");
            }
        }
    }

    private bool CheckLeftJoystickMovement()
    {
        Vector2 leftJoystick;
        InputDevice device = InputDevices.GetDeviceAtXRNode(leftHand);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftJoystick))
        {
            if (leftJoystick.magnitude > 0.1f)
            {
                movementTime += Time.deltaTime; // Incrementar timer
            }
        }
        return movementTime >= requiredTime; // Devuelve true si se ha movido lo suficiente
    }

    private bool CheckRightJoystickMovement()
    {
        Vector2 rightJoystick;
        InputDevice device = InputDevices.GetDeviceAtXRNode(rightHand);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightJoystick))
        {
            if (rightJoystick.magnitude > 0.1f)
            {
                movementTime += Time.deltaTime; // Incrementar timer
            }
        }
        return movementTime >= requiredTime; // Devuelve true si se ha movido lo suficiente
    }

    private bool CheckGrabbedObject()
    {
        float leftGrip;
        InputDevice device = InputDevices.GetDeviceAtXRNode(leftHand);
        if (device.TryGetFeatureValue(CommonUsages.grip, out leftGrip))
        {
            return leftGrip > 0.8f; // Se ha agarrado el objeto
        }
        return false;
    }

    private bool CheckUsedExtinguisher()
    {
        float rightTrigger;
        InputDevice device = InputDevices.GetDeviceAtXRNode(rightHand);
        if (device.TryGetFeatureValue(CommonUsages.trigger, out rightTrigger))
        {
            return rightTrigger > 0.8f; // Mantener presionado para usar el extintor
        }
        return false;
    }

    private bool CheckExitedBuilding()
    {
        // Verificar si el jugador cruzó la puerta de salida
        float distanceToExit = Vector3.Distance(transform.position, exitDoor.transform.position);
        return distanceToExit < 1.0f; // Umbral de distancia a la puerta
    }

    private void ShowTutorialText(string message)
    {
        if (tutorialText != null)
        {
            tutorialText.text = message;
        }
    }
}
