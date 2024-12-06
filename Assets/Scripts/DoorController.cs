using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject DoorObject;
    public GameObject RightController;

    private Door doorScript;
    void Start()
    {
        if (DoorObject != null) {
            doorScript = DoorObject.GetComponent<Door>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RightController != null && doorScript != null) { 
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                doorScript.MoveMyDoor();
            }
        }
    }
}
