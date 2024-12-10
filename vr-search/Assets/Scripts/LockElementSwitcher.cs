using System;
using System.Collections.Generic;
using UnityEngine;

public class LockElementSwitcher : MonoBehaviour
{
    public event Action<int> OnCurrentIndexChanged;
    private List<Texture> cryptoIcons;
    public int CurrentIndex { get; private set; } = 0;
    private void Start()
    {
        cryptoIcons = GetComponent<CryptoIconsContainer>().CryptoIcons;
    }
    public void ScrollUp()
    {
        CurrentIndex = (CurrentIndex + 1) % cryptoIcons.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }

    public void ScrollDown()
    {
        CurrentIndex = (CurrentIndex - 1 + cryptoIcons.Count) % cryptoIcons.Count;
        OnCurrentIndexChanged?.Invoke(CurrentIndex);
    }
}
