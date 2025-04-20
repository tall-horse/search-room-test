using System.Collections.Generic;
using System.Linq;

public class PasswordGenerator
{
    private DictionarySerializer dictionary;
    private System.Random random = new System.Random();

    public PasswordGenerator(DictionarySerializer dictionary)
    {
        this.dictionary = dictionary;
    }

    public List<int> Generate(int length)
    {
        var password = new List<int>();
        var availableElements = Enumerable.Range(0, dictionary.iconsWithNames.Count).ToList();
        int lastGenerated = -1;

        for (int i = 0; i < length; i++)
        {
            int index;
            do
            {
                index = random.Next(availableElements.Count);
            }
            while (availableElements[index] == lastGenerated);

            int selected = availableElements[index];
            availableElements.RemoveAt(index);
            password.Add(selected);
            lastGenerated = selected;
        }

        return password;
    }
}
