using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabPreventer : MonoBehaviour
{
    private LayerMask normalMask;
    [SerializeField] private LayerMask emptyMask;
    private XRRayInteractor teleporter;
    [SerializeField] private NearFarInteractor rightInteractor;
    void Awake()
    {
        teleporter = GetComponent<XRRayInteractor>();
    }
    void Start()
    {
        normalMask = teleporter.raycastMask;
        rightInteractor.selectEntered.AddListener(OnTeleportationPointed);
        rightInteractor.selectExited.AddListener(OnTeleportationStopped);
    }
    private void OnTeleportationStopped(SelectExitEventArgs arg0)
    {
        OnTeleportationStopped(rightInteractor);
    }
    private void OnTeleportationPointed(SelectEnterEventArgs arg0)
    {
        OnTeleportationPointed(rightInteractor);
    }
    public void OnTeleportationPointed(XRBaseInteractor interactor)
    {
        if (rightInteractor.interactablesSelected.Count > 0)
        {
            DoorHandleTag rightGrabbedHandle;
            rightInteractor.interactablesSelected[0].transform.TryGetComponent(out rightGrabbedHandle);

            if (rightGrabbedHandle != null)
            {
                teleporter.raycastMask = emptyMask;
                teleporter.allowHover = false;
                teleporter.allowSelect = false;
                teleporter.allowActivate = false;
                teleporter.gameObject.SetActive(false);
                Debug.Log("Teleportation disabled due to right hand grabbing an object.");
            }
        }
    }
    public void OnTeleportationStopped(XRBaseInteractor interactor)
    {
        teleporter.raycastMask = normalMask;
        teleporter.allowHover = true;
        teleporter.allowSelect = true;
        teleporter.allowActivate = true;
        teleporter.gameObject.SetActive(false);
        Debug.Log("Teleportation re-enabled, ray is inactive until user input.");
    }
    public void EnableTeleportationRay()
    {
        teleporter.gameObject.SetActive(true);
        Debug.Log("Teleportation ray activated by user input.");
    }
    private void OnDestroy()
    {
        rightInteractor.selectEntered.RemoveListener(OnTeleportationPointed);
        rightInteractor.selectExited.RemoveListener(OnTeleportationStopped);
    }
}
