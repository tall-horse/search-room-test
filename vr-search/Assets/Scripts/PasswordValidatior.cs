using System.Linq;

public class PasswordValidator
{
    private bool[] correctness;

    public PasswordValidator(int length)
    {
        correctness = new bool[length];
    }

    public void Update(int index, bool isCorrect)
    {
        correctness[index] = isCorrect;
    }

    public bool IsPasswordCorrect => correctness.All(x => x);
}

