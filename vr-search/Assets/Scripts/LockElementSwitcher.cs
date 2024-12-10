using System;
using System.Collections.Generic;
using UnityEngine;

public class LockElementSwitcher : MonoBehaviour
{
    public event Action<string> OnNameSent;
    public event Action<int> OnCurrentIndexChanged;
    private DictionarySerializer cryptoIcons;
    public int CurrentIndex { get; private set; } = 0;
    private void Start()
    {
        cryptoIcons = GetComponentInParent<DictionarySerializer>();
    }
    public void ScrollUp()
    {
        CurrentIndex = (CurrentIndex + 1) % cryptoIcons.iconsWithNames.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }

    public void ScrollDown()
    {
        CurrentIndex = (CurrentIndex - 1 + cryptoIcons.iconsWithNames.Count) % cryptoIcons.iconsWithNames.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }
}
