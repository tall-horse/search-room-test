using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HandleAnimationController : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private Animator animator;

    private void Awake()
    {
        // Try to get the components in the children of this GameObject
        interactable = GetComponentInChildren<XRGrabInteractable>();
        animator = GetComponentInChildren<Animator>();

        // Null check to ensure that both components exist
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
            // Add listeners only if interactable is found
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            // Remove listeners to avoid memory leaks
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
