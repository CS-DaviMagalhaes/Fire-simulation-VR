using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice _rightController;
    public InputDevice _leftController;
    public InputDevice _HMD;

    public ParticleSystem particleSystem;

    private bool isHoldingObject = false;
    private GameObject heldObject; // Reference to the currently held object
    private Collider heldObjectCollider; // Collider of the held object

    private InputFeatureUsage<float> triggerButton = CommonUsages.trigger;

    void Update()
    {
        if (!_rightController.isValid || !_leftController.isValid || !_HMD.isValid)
        {
            InitializeInputDevices();
        }

        float rightTriggerValue = 0.0f;
        float leftTriggerValue = 0.0f;

        if (_rightController.TryGetFeatureValue(triggerButton, out rightTriggerValue))
        {
            isHoldingObject = rightTriggerValue > 0.1f;
        }

        if (_leftController.TryGetFeatureValue(triggerButton, out leftTriggerValue))
        {
            isHoldingObject = leftTriggerValue > 0.1f;
        }

        HandleObjectInteraction();

        if (isHoldingObject)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }

    private void HandleObjectInteraction()
    {
        if (isHoldingObject)
        {
            // Detect the object being held (you can implement a raycast or collision detection here)
            if (heldObject == null)
            {
                heldObject = DetectGrabbableObject(); // Replace with your logic to find the object
                if (heldObject != null)
                {
                    heldObjectCollider = heldObject.GetComponent<Collider>();
                    if (heldObjectCollider != null)
                    {
                        heldObjectCollider.enabled = false; // Disable the collider
                    }
                }
            }
        }
        else
        {
            // Release the object
            if (heldObject != null)
            {
                if (heldObjectCollider != null)
                {
                    heldObjectCollider.enabled = true; // Re-enable the collider
                }
                heldObject = null;
            }
        }
    }

    private GameObject DetectGrabbableObject()
    {
        // Implement logic to detect the grabbable object
        // For example, using a raycast or trigger detection
        Ray ray = new Ray(transform.position, transform.forward); // Adjust as needed
        if (Physics.Raycast(ray, out RaycastHit hit, 2f)) // Adjust the range
        {
            if (hit.collider.CompareTag("Grabbable")) // Ensure the object has a "Grabbable" tag
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    private void InitializeInputDevices()
    {
        if (!_rightController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        if (!_leftController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        if (!_HMD.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref _HMD);
    }

    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
}
