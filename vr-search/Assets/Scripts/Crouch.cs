using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crouch : MonoBehaviour
{
    [SerializeField] private float crouchHeight = 0.6f;
    [SerializeField] private InputActionReference crouchAction;
    private bool isCrouching = false;
    private XROrigin xROrigin;
    private float standHeight = 1.8f;
    private void Awake()
    {
        xROrigin = GetComponent<XROrigin>();
        SubscribeCrouch();
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        standHeight = xROrigin.CameraYOffset;
    }

    private void ToggleCrouch(InputAction.CallbackContext context)
    {
        isCrouching = !isCrouching;
        xROrigin.CameraYOffset = isCrouching ? crouchHeight : standHeight;
    }
    private void SubscribeCrouch()
    {
        crouchAction.action.Enable();
        crouchAction.action.performed += ToggleCrouch;
    }
    private void UnsubscribeCrouch()
    {
        crouchAction.action.Disable();
        crouchAction.action.performed -= ToggleCrouch;
    }
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                UnsubscribeCrouch();
                break;
            case InputDeviceChange.Reconnected:
                SubscribeCrouch();
                break;
        }
    }
}
