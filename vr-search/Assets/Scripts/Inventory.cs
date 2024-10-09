using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Inventory : MonoBehaviour
{
    private CallbackTest callbackTest;
    public XRGrabInteractable hoveredInteractable;
    public XRGrabInteractable leftHandGrabbedInteractable;
    public XRGrabInteractable rightHandGrabbedInteractable;
    private void Awake() {
        callbackTest = FindAnyObjectByType<CallbackTest>();
    }

    private void Start() {
        callbackTest.OnGrabbed += Grab;
        callbackTest.OnDropped += Drop;
    }
    private void Grab()
    {
        //leftHandGrabbedInteractable = 
    }

    private void Drop()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
