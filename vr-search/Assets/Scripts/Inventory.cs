using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public event Action<bool> OnInventoryToggled;
    [SerializeField] private InputActionReference inventoryAction;
    [SerializeField] private GameObject inventoryObject;
    public bool IsOpened { get; private set; } = false;
    private void Awake()
    {
        SubscribeInventory();
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    void Start()
    {
        ActivateSlots(false);
    }

    private void SubscribeInventory()
    {
        inventoryAction.action.Enable();
        inventoryAction.action.performed += ToggleInventory;
    }

    private void ToggleInventory(InputAction.CallbackContext context)
    {
        IsOpened = !IsOpened;
        ActivateSlots(IsOpened);
    }

    private void ActivateSlots(bool toActivate)
    {
        OnInventoryToggled?.Invoke(toActivate);
        var slotChildren = inventoryObject.GetComponentsInChildren<Transform>().ToList();
        foreach (var child in slotChildren)
        {
            MeshRenderer childVisual;
            child.TryGetComponent(out childVisual);
            if (childVisual != null)
            {
                childVisual.enabled = toActivate;
            }
            Collider slotCollider;
            child.TryGetComponent(out slotCollider);
            if (slotCollider != null)
            {
                slotCollider.enabled = toActivate;
            }
        }
    }

    private void UnSubscribeInventory()
    {
        inventoryAction.action.Disable();
        inventoryAction.action.performed -= ToggleInventory;
    }
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                UnSubscribeInventory();
                break;
            case InputDeviceChange.Reconnected:
                SubscribeInventory();
                break;
        }
    }
}
