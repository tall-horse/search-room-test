using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class HandleAnimationController : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable interactable;
    private void Awake()
    {
        Debug.Log("Awake");
        animator = GetComponentInChildren<Animator>();
        interactable = GetComponentInChildren<XRGrabInteractable>();
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }
    private void OnGrab(SelectEnterEventArgs arg0)
    {
        animator.SetBool("IsOpening", true);
    }
    private void OnRelease(SelectExitEventArgs arg0)
    {
        animator.SetBool("IsOpening", false);
    }
}
