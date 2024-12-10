using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockElementSwitcherUI : MonoBehaviour
{

    [SerializeField] private RawImage columnIcon;
    private List<Texture> cryptoIcons;
    private LockElementSwitcher lockElementSwitcher;
    private void Awake()
    {
        cryptoIcons = GetComponent<CryptoIconsContainer>().CryptoIcons;
        lockElementSwitcher = GetComponent<LockElementSwitcher>();
    }
    private void Start()
    {
        lockElementSwitcher.OnCurrentIndexChanged += UpdateIconUI;
    }

    private void UpdateIconUI(int index)
    {
        columnIcon.texture = cryptoIcons[index];
    }
}
