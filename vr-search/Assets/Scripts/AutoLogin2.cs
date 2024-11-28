using System.Collections.Generic;
using BlueTea.Core.Api;
using BlueTea.UI.Components;
using BlueTea.UI.Services;
using UnityEngine;
using UnityEngine.UIElements;
namespace VR
{
    public class AutoLogin2 : MonoBehaviour
    {
        [SerializeField] private string email;
        [SerializeField] private string password;
        private void Start()
        {
            UIDocument uiDocument = FindFirstObjectByType<UIDocument>(FindObjectsInactive.Exclude);
            DisableInputFields(uiDocument.rootVisualElement);
            UiService.Instance.ToggleOverlay(true, true);
            VirtualStudioService.Instance.Authenticate(email, password, false);
        }
        private void DisableInputFields(VisualElement uiDocument)
        {
            List<InputField> inputFields = uiDocument.Query<InputField>().Where(element => element.name is "EmailInputField" or "PasswordInputField").ToList();
            uiDocument.Q<Checkbox>("RememberMeCheckbox")?.SetEnabled(false);
            foreach (InputField inputField in inputFields)
            {
                inputField.SetEnabled(false);
            }
        }
    }
}