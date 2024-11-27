using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject toOpen;
    [SerializeField] private XRGrabInteractable key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            }
        }
    }
}
