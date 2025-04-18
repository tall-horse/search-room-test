using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TooltipController : MonoBehaviour
{
    private const string TooltipTag = "Tooltip";
    [SerializeField] private InputActionReference showTooltipAction;
    private List<GameObject> tooltips = new List<GameObject>();
    private void Awake()
    {
        tooltips = GameObject.FindGameObjectsWithTag(TooltipTag).ToList();
        SubscribeShowTooltip();
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void Start()
    {
        tooltips.ForEach(t => t.SetActive(false));
    }

    private void OnDestroy()
    {
        UnsubscribeShowTooltip();
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    private void ToggleTooltip(InputAction.CallbackContext context)
    {
        tooltips.ForEach(t => t.SetActive(!t.activeSelf));
    }
    public void SubscribeShowTooltip()
    {
        showTooltipAction.action.Enable();
        showTooltipAction.action.performed += ToggleTooltip;
    }
    public void UnsubscribeShowTooltip()
    {
        showTooltipAction.action.Disable();
        showTooltipAction.action.performed -= ToggleTooltip;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                UnsubscribeShowTooltip();
                break;
            case InputDeviceChange.Reconnected:
                SubscribeShowTooltip();
                break;
        }
    }
}