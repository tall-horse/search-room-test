using System;

public class PasswordElement
{
    public PasswordElement(int correctValue, int digitNumber, PasswordValidator validator)
    {
        _correctValue = correctValue;
        _digitNumber = digitNumber;
        _validator = validator;
        ChangeValue(currentvalue);
    }

    private PasswordValidator _validator;
    private PasswordChecker _passwordChecker;
    private int currentvalue = 0;
    private int _correctValue;
    private int _digitNumber;
    public bool IsValueCorrect { get; private set; }
    public event Action OnValueChanged;
    public void CheckValue()
    {
        IsValueCorrect = currentvalue == _correctValue;
        _validator.Update(_digitNumber, IsValueCorrect);
    }
    public void ChangeValue(int newValue)
    {
        currentvalue = newValue;
        CheckValue();
        OnValueChanged?.Invoke();
    }
}
