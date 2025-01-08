using Unity.XR.CoreUtils;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private XROrigin player;
    [SerializeField] private Transform initialPlayerPosition;
    [SerializeField] private Transform startTutorialPosition;
    [SerializeField] private Transform startSearchPosition;
    private void Awake()
    {
        player = FindAnyObjectByType<XROrigin>();
    }
    private void Start()
    {
        TeleportToStart();
    }
    private void TeleportPlayer(Transform teleportTo)
    {
        player.transform.position = teleportTo.position;
        player.transform.rotation = teleportTo.rotation;
    }
    public void TeleportToStart()
    {
        TeleportPlayer(initialPlayerPosition);
    }
    public void TeleportToTutorial()
    {
        TeleportPlayer(startTutorialPosition);
    }
    public void TeleportToApartment()
    {
        TeleportPlayer(startSearchPosition);
    }
}
