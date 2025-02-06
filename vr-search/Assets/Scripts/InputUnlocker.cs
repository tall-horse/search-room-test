using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Events;

public class InputUnlocker : MonoBehaviour
{
    public UnityEvent OnZoneEntered;
    private XROrigin player;
    private void Awake()
    {
        player = FindFirstObjectByType<XROrigin>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.gameObject == player.gameObject;
        if (isPlayer == true)
        {
            OnZoneEntered?.Invoke();
        }
    }
}
