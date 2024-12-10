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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passwordChecker.OnNameSent += DisplayName;
    }

    private void DisplayName(string name)
    {
        hintText.text = name;
    }
}
