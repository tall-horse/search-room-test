using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PasswordChecker : MonoBehaviour
{
    public UnityEvent OnSafeOpened;
    private List<LockElementSwitcher> passwordElements = new List<LockElementSwitcher>();
    private int passwordLength;
    private List<int> password;
    [HideInInspector] public List<bool> intermediateResult = new List<bool>();
    private List<PasswordElement> passwordElementComponents = new List<PasswordElement>();
    private void Awake()
    {
        passwordElements = GetComponentsInChildren<LockElementSwitcher>().ToList();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passwordLength = passwordElements.Count();
        GeneratePassword();
        for (int i = 0; i < passwordLength; i++)
        {
            passwordElementComponents.Add(new PasswordElement(this, password[i], i));
            passwordElements[i].OnCurrentIndexChanged += passwordElementComponents[i].ChangeValue;
            passwordElementComponents[i].OnValueChanged += CheckPassword;
        }
    }
    private void GeneratePassword()
    {
        password = new List<int> { 0, 1, 2 };
        foreach (var item in password)
        {
            intermediateResult.Add(false);
        }
    }
    private void CheckPassword()
    {
        bool allTrue = intermediateResult.All(b => b);
        if (allTrue)
        {
            OnSafeOpened.Invoke();
        }
    }
}
