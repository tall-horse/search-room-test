using TMPro;
using UnityEngine;

public class SafeLockSectionHint : MonoBehaviour
{
    private PasswordProgressTracker passwordProgressTracker;
    private TextMeshProUGUI hintText;
    private void Awake()
    {
        hintText = GetComponent<TextMeshProUGUI>();
        passwordProgressTracker = GetComponentInParent<PasswordProgressTracker>();
        passwordProgressTracker.OnNameSent += (hint, value) =>
        {
            if (hint == this)
            {
                DisplayName(value);

            }
        };
    }

    private void DisplayName(string name)
    {
        if (name == null)
        {
            Debug.LogError("Hint: is null");
            return;
        }
        if (name == "")
        {
            Debug.LogError("Hint is an empty string");
            return;
        }
        hintText.text = name;
    }
}
