using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockElementSwitcherUI : MonoBehaviour
{
    [SerializeField] private RawImage columnIcon;
    [SerializeField] private List<Texture> cryptoIcons;
    private int currentIndex = 0;

    public void ScrollUp()
    {
        currentIndex = (currentIndex + 1) % cryptoIcons.Count;
        columnIcon.texture = cryptoIcons[currentIndex];
    }

    public void ScrollDown()
    {
        currentIndex = (currentIndex - 1 + cryptoIcons.Count) % cryptoIcons.Count;
        columnIcon.texture = cryptoIcons[currentIndex];
    }
}
