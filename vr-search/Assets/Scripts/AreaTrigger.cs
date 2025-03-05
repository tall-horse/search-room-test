using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject toOpen;
    [SerializeField] private XRGrabInteractable key;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (toOpen.activeSelf == false)
            return;

        if (other.gameObject == key.gameObject)
        {
            if (key.isSelected == false)
            {
                toOpen.SetActive(false);
                audioSource.Play();
            }
        }
    }
}
