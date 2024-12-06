using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class posExtintor : MonoBehaviour
{
    public OVRInput.Controller controller;
    public Collider cd;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller) > 0.1f)
        {
            if (cd != null)
            {
                cd.enabled = false;
            }


        }
        else
        { 
            if (cd == null)
            {
                cd.enabled = true;
            }
        }
    }
}
