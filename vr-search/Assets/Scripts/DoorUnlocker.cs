using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DoorUnlocker : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private const string IsOpened = "IsOpened";
    private Animator animator;
    private XRSocketInteractor socketInteractor;
    private Rigidbody doorRigidbody;
    private void Awake()
    {
        doorRigidbody = GetComponentInParent<HingeJoint>().gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInParent<Animator>();
        socketInteractor = GetComponentInParent<XRSocketInteractor>();
    }

    private void Start()
    {
        doorRigidbody.isKinematic = true;
        socketInteractor.selectEntered.AddListener(UnlockDoor);
    }

    private void UnlockDoor(SelectEnterEventArgs arg0)
    {
        animator.SetBool(IsOpened, true);
        IXRSelectInteractable key = arg0.interactableObject;
        var keyObj = key.colliders[0].gameObject;
        keyObj.transform.SetParent(keyObj.transform);
        keyObj.GetComponent<Key>().TurnKey();
    }

    public void OpenDoor()
    {
        doorRigidbody.isKinematic = false;
        transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
