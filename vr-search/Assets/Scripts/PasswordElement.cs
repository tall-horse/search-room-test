using System;

public class PasswordElement
{
    public PasswordElement(PasswordChecker passwordChecker, int correctValue, int digitNumber)
    {
        _passwordChecker = passwordChecker;
        _correctValue = correctValue;
        _digitNumber = digitNumber;
        ChangeValue(currentvalue);
    }
    private PasswordChecker _passwordChecker;
    private int currentvalue = 0;
    private int _correctValue;
    private int _digitNumber;
    public bool IsValueCorrect { get; private set; }
    public event Action OnValueChanged;
    public void CheckValue()
    {
        IsValueCorrect = currentvalue == _correctValue;
    }
    public void ChangeValue(int newValue)
    {
        currentvalue = newValue;
        CheckValue();
        _passwordChecker.intermediateResult[_digitNumber] = IsValueCorrect;
        OnValueChanged?.Invoke();
    }
}
