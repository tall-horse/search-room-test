using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] private InputActionReference menuAction;
    private bool isPaused = false;
    private void Awake()
    {
        SubscribeMenu();
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void ToggleMenu(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        Debug.Log("Pause is: " + isPaused);
    }
    private void SubscribeMenu()
    {
        menuAction.action.Enable();
        menuAction.action.performed += ToggleMenu;
    }
    private void UnsubscribeMenu()
    {
        menuAction.action.Disable();
        menuAction.action.performed -= ToggleMenu;
    }
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                UnsubscribeMenu();
                break;
            case InputDeviceChange.Reconnected:
                SubscribeMenu();
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
