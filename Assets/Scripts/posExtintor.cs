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
    private XRGrabInteractable grabInteractable;
    //private Grabbable grabInteractable;
    private Rigidbody rb;
    private Collider extintorCollider;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        extintorCollider = GetComponent<Collider>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }
    private void OnGrab(SelectEnterEventArgs args)
    {
        // Acceder al interactorObject en lugar de interactor
        Transform handTransform = args.interactorObject.transform;

        // Colocar el extintor en la mano del controlador
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;

        // Desactivar el Collider para evitar problemas de colisiones mientras se sostiene el extintor
        extintorCollider.enabled = false;

        // Hacer que el Rigidbody sea cinemático para que no se mueva por la física mientras se sostiene
        rb.isKinematic = true;
    }

    // Este evento se ejecuta cuando se suelta el extintor
    private void OnRelease(SelectExitEventArgs args)
    {
        // Reactivar el Collider para permitir interacciones físicas
        extintorCollider.enabled = true;

        // Hacer que el Rigidbody no sea cinemático, permitiendo que el extintor caiga por gravedad
        rb.isKinematic = false;
    }

    /*
    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
    */
}
