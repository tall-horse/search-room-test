using System;
using UnityEngine;

public class LockElementSwitcher : MonoBehaviour
{
    public event Action<int> OnCurrentIndexChanged;
    private DictionarySerializer cryptoIcons;
    public int CurrentIndex { get; private set; } = 0;
    private void Start()
    {
        cryptoIcons = GetComponentInParent<DictionarySerializer>();
    }
    public void ScrollUp()
    {
        CurrentIndex = (CurrentIndex + 1) % cryptoIcons.iconsWithNamesDictionary.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }

    public void ScrollDown()
    {
        CurrentIndex = (CurrentIndex - 1 + cryptoIcons.iconsWithNamesDictionary.Count) % cryptoIcons.iconsWithNamesDictionary.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }
}
