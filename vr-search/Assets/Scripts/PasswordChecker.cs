using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordChecker : MonoBehaviour
{
    public UnityEvent OnSafeOpened;
    public event Action<SafeLockSectionHint, string> OnNameSent;
    private List<LockElementSwitcher> passwordUIElements = new List<LockElementSwitcher>();
    private List<int> password;
    private PasswordElement[] passwordLogicElements;
    private DictionarySerializer dictionarySerializer;
    private System.Random random = new System.Random();
    private PasswordValidator passwordValidator;
    private int passwordLength;
    private void Awake()
    {
        dictionarySerializer = GetComponent<DictionarySerializer>();
        passwordUIElements = GetComponentsInChildren<LockElementSwitcher>().ToList();
    }
    void Start()
    {

        passwordLength = passwordUIElements.Count(); //3
        passwordLogicElements = new PasswordElement[passwordLength];
        passwordValidator = new PasswordValidator(passwordLength);
        GeneratePassword();
        SetupPasswordComponents(passwordLength);
    }
    private void GeneratePassword()
    {
        var generator = new PasswordGenerator(dictionarySerializer);
        password = generator.Generate(passwordLength);
    }
    private void SetupPasswordComponents(int passwordLength)
    {
        SafeLockSectionHint[] safeLockHints = GetComponentsInChildren<SafeLockSectionHint>();
        for (int i = 0; i < passwordLength; i++)
        {
            passwordLogicElements[i] = new PasswordElement(password[i], i, passwordValidator);
            passwordUIElements[i].OnCurrentIndexChanged += passwordLogicElements[i].ChangeValue;
            OnNameSent?.Invoke(safeLockHints[i], dictionarySerializer.AccessByIndex(password[i]).Value);
            passwordLogicElements[i].OnValueChanged += CheckPassword;
        }
    }

    private void CheckPassword()
    {
        if (passwordValidator.IsPasswordCorrect)
        {
            OnSafeOpened.Invoke();
        }
    }
}
