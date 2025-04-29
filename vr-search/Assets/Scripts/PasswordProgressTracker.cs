using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordProgressTracker : MonoBehaviour
{
    public UnityEvent OnSafeOpened;
    public event Action<SafeLockSectionHint, string> OnNameSent;
    private List<LockElementSwitcher> passwordUIElements = new List<LockElementSwitcher>();
    private List<int> password;
    private PasswordElement[] passwordLogicElements;
    private DictionarySerializer dictionarySerializer;
    private PasswordValidator passwordValidator;
    private int passwordLength;
    private SafeLockSectionHint[] safeLockHints;
    private void Awake()
    {
        safeLockHints = GetComponentsInChildren<SafeLockSectionHint>();
        dictionarySerializer = GetComponent<DictionarySerializer>();
        passwordUIElements = GetComponentsInChildren<LockElementSwitcher>().ToList();
        passwordLength = passwordUIElements.Count(); //3
        passwordLogicElements = new PasswordElement[passwordLength];
        passwordValidator = new PasswordValidator(passwordLength);
        GeneratePassword();
    }
    void Start()
    {
        SetupPasswordComponents(passwordLength);
    }
    private void GeneratePassword()
    {
        var generator = new PasswordGenerator(dictionarySerializer);
        password = generator.Generate(passwordLength);
    }
    private void SetupPasswordComponents(int passwordLength)
    {
        for (int i = 0; i < passwordLength; i++)
        {
            passwordLogicElements[i] = new PasswordElement(password[i], i, passwordValidator);
            passwordUIElements[i].OnCurrentIndexChanged += passwordLogicElements[i].ChangeValue;
            string hint = dictionarySerializer.AccessByIndex(password[i]).Value;
            OnNameSent?.Invoke(safeLockHints[i], hint);
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
