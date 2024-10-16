using Unity.XR.CoreUtils;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
     private XROrigin player;
    [SerializeField] private Transform teleportPoint;
    private void Awake() {
        player = FindAnyObjectByType<XROrigin>();
    }
    public void TeleportPlayer()
    {
        player.transform.position = teleportPoint.position;
        player.transform.rotation = teleportPoint.rotation;
    }
}
