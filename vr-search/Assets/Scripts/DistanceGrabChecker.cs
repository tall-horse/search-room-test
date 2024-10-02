using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DistanceGrabChecker : MonoBehaviour
{
    public XRGrabInteractable interactable;
    public Transform xrController; // Assign the XR controller transform
    public float maxDistance = 2.0f; // Set your maximum grab distance

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }
    private void Awake() {
        interactable = GetComponent<XRGrabInteractable>();
    }
    private void OnRelease(SelectExitEventArgs arg0)
    {
        StopAllCoroutines();
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        StartCoroutine(CheckDistance());
    }


    private System.Collections.IEnumerator CheckDistance()
    {
        while (interactable.isSelected)
        {
            if (Vector3.Distance(xrController.position, interactable.transform.position) > maxDistance)
            {
                interactable.interactionManager.CancelInteractableFocus(interactable);
            }

            yield return null; // Wait for the next frame
        }
    }
}
