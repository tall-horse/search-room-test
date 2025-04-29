using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

// TODO: Replace with an alternative system
public class InvenrotySlot : MonoBehaviour
{
    private XRSocketInteractor socketInteractor;
    private Vector3 currentObjectInitialScale;
    private Transform initialObjectParent;
    private Vector3 pocketScale = new Vector3(0.25f, 0.25f, 0.25f);
    private readonly Vector3 slotScale = new Vector3(0.2f, 0.2f, 0.2f);
    private Transform objectInASlot = null;
    void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    void Start()
    {
        socketInteractor.selectEntered.AddListener(PutInASlot);
        socketInteractor.selectExited.AddListener(TakeOutOfPocket);
    }

    private void PutInASlotNoArgs()
    {
        if (socketInteractor.interactablesSelected.Count > 1
        )
            return;
        objectInASlot = socketInteractor.interactablesSelected[0].transform;
        initialObjectParent = objectInASlot.parent;
        currentObjectInitialScale = objectInASlot.localScale;
        objectInASlot.GetComponentsInChildren<Collider>().ToList().ForEach(c => c.isTrigger = true);
        objectInASlot.GetComponent<Rigidbody>().useGravity = false;
        pocketScale = objectInASlot.transform.localScale + slotScale;
        objectInASlot.transform.localScale = pocketScale;
        objectInASlot.SetParent(transform);
    }
    private void PutInASlot(SelectEnterEventArgs arg0)
    {
        PutInASlotNoArgs();
    }
    private void TakeOutOfPocketNoArgs()
    {
        objectInASlot.localScale = currentObjectInitialScale;
        objectInASlot.GetComponentsInChildren<Collider>().ToList().ForEach(c => c.isTrigger = false);
        objectInASlot.GetComponent<Rigidbody>().useGravity = true;
        objectInASlot.parent = initialObjectParent;
    }
    private void TakeOutOfPocket(SelectExitEventArgs arg0)
    {
        TakeOutOfPocketNoArgs();
    }
}
