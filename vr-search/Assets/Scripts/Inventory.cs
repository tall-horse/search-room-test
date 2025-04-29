using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Inventory : MonoBehaviour
{
    public event Action<bool> OnInventoryToggled;
    [SerializeField] private InputActionReference inventoryAction;
    [SerializeField] private GameObject inventoryObject;
    private DynamicMoveProvider movement;
    private SnapTurnProvider turning;
    public bool IsOpened { get; private set; } = false;
    private void Awake()
    {
        movement = GetComponentInChildren<DynamicMoveProvider>();
        turning = GetComponentInChildren<SnapTurnProvider>();
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
        movement.enabled = !toActivate;
        turning.enabled = !toActivate;
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
