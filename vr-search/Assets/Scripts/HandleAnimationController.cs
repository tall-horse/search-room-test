using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HandleAnimationController : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private Animator animator;

    private void Awake()
    {
        interactable = GetComponentInChildren<XRGrabInteractable>();
        animator = GetComponentInChildren<Animator>();

        if (interactable == null)
        {
            Debug.LogError("XRGrabInteractable component not found in children! Object: " + name);
        }
        if (animator == null)
        {
            Debug.LogError("Animator component not found in children! Object: " + name);
        }
    }

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnGrab);
            interactable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        if (animator != null)
        {
            animator.SetBool("IsOpening", true);
        }
    }

    private void OnRelease(SelectExitEventArgs arg0)
    {
        if (animator != null)
        {
            animator.SetBool("IsOpening", false);
        }
    }
}
