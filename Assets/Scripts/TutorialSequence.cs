using UnityEngine;
using UnityEngine.XR;

public class TutorialSequence : MonoBehaviour
{
    public GameObject fireExtinguisher; // Asignar el extintor en el editor
    public GameObject exitDoor; // Asignar la puerta de salida en el editor
    public TMPro.TextMeshProUGUI tutorialText; // Campo para mostrar el texto del tutorial
    public bool fireExtinguished; // Esta variable será actualizada por otro script

    private bool hasMovedWithLeftJoystick = false;
    private bool hasMovedWithRightJoystick = false;
    private bool hasGrabbedExtinguisher = false;
    private bool hasUsedExtinguisher = false;
    private bool hasExitedBuilding = false;

    private XRNode leftHand = XRNode.LeftHand;
    private XRNode rightHand = XRNode.RightHand;

    private void Start()
    {
        ShowTutorialText("Mira a tu alrededor utilizando el joystick izquierdo");
    }

    private void Update()
    {
        if (!hasMovedWithLeftJoystick)
        {
            if (CheckLeftJoystickMovement())
            {
                hasMovedWithLeftJoystick = true;
                ShowTutorialText("Camina hacia el extintor usando los joysticks");
            }
        }
        else if (!hasMovedWithRightJoystick)
        {
            if (CheckRightJoystickMovement())
            {
                hasMovedWithRightJoystick = true;
                ShowTutorialText("Agarra el extintor utilizando el trigger izquierdo secundario");
            }
        }
        else if (!hasGrabbedExtinguisher)
        {
            if (CheckGrabbedObject())
            {
                hasGrabbedExtinguisher = true;
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
            return leftJoystick.magnitude > 0.1f;
        }
        return false;
    }

    private bool CheckRightJoystickMovement()
    {
        Vector2 rightJoystick;
        InputDevice device = InputDevices.GetDeviceAtXRNode(rightHand);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightJoystick))
        {
            return rightJoystick.magnitude > 0.1f;
        }
        return false;
    }

    private bool CheckGrabbedObject()
    {
        float leftGrip;
        InputDevice device = InputDevices.GetDeviceAtXRNode(leftHand);
        if (device.TryGetFeatureValue(CommonUsages.grip, out leftGrip))
        {
            return leftGrip > 0.8f; // Umbral para verificar que el objeto fue agarrado
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
