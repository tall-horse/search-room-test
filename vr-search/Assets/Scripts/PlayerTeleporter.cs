using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleporter : MonoBehaviour
{
    public UnityEvent OnPlayerTeleportedToTutorial;
    public UnityEvent OnPlayerTeleportedToApartment;
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
        OnPlayerTeleportedToTutorial?.Invoke();
    }
    public void TeleportToApartment()
    {
        TeleportPlayer(startSearchPosition);
        OnPlayerTeleportedToApartment?.Invoke();
    }
}
