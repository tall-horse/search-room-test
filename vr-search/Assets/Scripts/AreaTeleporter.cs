using Unity.XR.CoreUtils;
using UnityEngine;

public class AreaTeleporter : MonoBehaviour
{
    private PlayerTeleporter playerTeleporter;
    private void Awake()
    {
        playerTeleporter = FindAnyObjectByType<PlayerTeleporter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XROrigin>() != null)
        {
            playerTeleporter.TeleportToApartment();
        }
    }
}
