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
    private List<LockElementSwitcher> passwordElements = new List<LockElementSwitcher>();
    private List<int> password;
    [HideInInspector] public List<bool> intermediateResult = new List<bool>();
    private List<PasswordElement> passwordElementComponents = new List<PasswordElement>();
    private DictionarySerializer dictionarySerializer;
    private System.Random random = new System.Random();
    private int passwordLength;
    private void Awake()
    {
        dictionarySerializer = GetComponent<DictionarySerializer>();
        passwordElements = GetComponentsInChildren<LockElementSwitcher>().ToList();
    }
    void Start()
    {

        passwordLength = passwordElements.Count(); //3
        GeneratePassword();
        SetupPasswordComponents(passwordLength);
    }
    private void GeneratePassword()
    {
        password = new List<int>();
        List<int> availableElements = new List<int>();
        int randomIndex;
        int lastGeneratedNumber = -1;
        if (dictionarySerializer.iconsWithNames == null) Debug.Log("ds is null ");
        for (int i = 0; i < dictionarySerializer.iconsWithNames.Count; i++)
        {
            availableElements.Add(i);
        }

        for (int i = 0; i < passwordLength; i++)
        {
            do
            {
                randomIndex = random.Next(0, availableElements.Count);
            }
            while (availableElements[randomIndex] == lastGeneratedNumber);
            int selectedNumber = availableElements[randomIndex];

            availableElements.RemoveAt(randomIndex);
            password.Add(selectedNumber);
            lastGeneratedNumber = selectedNumber;
        }
        foreach (var item in password)
        {
            intermediateResult.Add(false);
        }
    }
    private void SetupPasswordComponents(int passwordLength)
    {
        SafeLockSectionHint[] safeLockHints = GetComponentsInChildren<SafeLockSectionHint>();
        for (int i = 0; i < passwordLength; i++)
        {
            passwordElementComponents.Add(new PasswordElement(this, password[i], i));
            passwordElements[i].OnCurrentIndexChanged += passwordElementComponents[i].ChangeValue;
            OnNameSent?.Invoke(safeLockHints[i], dictionarySerializer.AccessByIndex(password[i]).Value);
            passwordElementComponents[i].OnValueChanged += CheckPassword;
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
