using TMPro;
using UnityEngine;

public class SafeLockSectionHint : MonoBehaviour
{
    private PasswordChecker passwordChecker;
    private TextMeshProUGUI hintText;
    private void Awake()
    {
        hintText = GetComponent<TextMeshProUGUI>();
        passwordChecker = GetComponentInParent<PasswordChecker>();
    }

    void Start()
    {
        passwordChecker.OnNameSent += (hint, value) =>
        {
            if (hint == this)
                DisplayName(value);
        };
    }

    private void DisplayName(string name)
    {
        if (name != "" && name != null)
        {
            Debug.Log("Hint: " + name);
        }
        if (name == "")
        {
            Debug.Log("Empty string");
        }
        if (name == null)
        {
            Debug.LogError("name is null");
            return;
        }
        hintText.text = name;
    }
}
