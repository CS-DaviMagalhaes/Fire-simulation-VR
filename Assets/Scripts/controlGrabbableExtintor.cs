using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;

public class controlGrabbableExtintor : MonoBehaviour
{
    public Grabbable grabbable;
    public GrabInteractable interactable;
    public Collider _collider;
    public PhysicsGrabbable phyGrabbable;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();

        phyGrabbable = GetComponent<PhysicsGrabbable>();
        grabbable = GetComponent<Grabbable>();
        interactable = GetComponent<GrabInteractable>();

        if (interactable.IsInvoking()) {
            Update();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _collider.enabled = false;

    }
}
