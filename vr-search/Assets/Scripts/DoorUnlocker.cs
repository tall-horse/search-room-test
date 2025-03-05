using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DoorUnlocker : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private const string IsOpened = "IsOpened";
    private Animator animator;
    private XRSocketInteractor socketInteractor;
    private Rigidbody doorRigidbody;
    private AudioSource audioSource;
    private void Awake()
    {
        doorRigidbody = GetComponentInParent<HingeJoint>().gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInParent<Animator>();
        socketInteractor = GetComponentInParent<XRSocketInteractor>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        doorRigidbody.isKinematic = true;
        socketInteractor.selectEntered.AddListener(UnlockDoor);
    }

    private void UnlockDoor(SelectEnterEventArgs arg0)
    {
        var keyComponent = arg0.interactableObject.colliders[0].gameObject.GetComponent<Key>();
        if (keyComponent == null)
            return;
        if (keyComponent.DoorToUnlock != door)
            return;
        animator.SetBool(IsOpened, true);
        keyComponent.transform.SetParent(keyComponent.transform);
        keyComponent.TurnKey();
        audioSource.Play();
    }

    public void OpenDoor()
    {
        doorRigidbody.isKinematic = false;
        //transform.parent.gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }
}
