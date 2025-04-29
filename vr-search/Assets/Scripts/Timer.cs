using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalSeconds;
    private float remainingTime;
    private bool isTicking = false;
    public event Action<int, int> OnTimerTicked;
    void Start()
    {
        remainingTime = totalSeconds;
        StartTimer();
        InvokeRepeating(nameof(UpdateTimer), 1f, 1f);
    }

    public void StartTimer()
    {
        isTicking = true;
    }

    public void StopTimer()
    {
        isTicking = false;
    }

    private void UpdateTimer()
    {
        if (isTicking == false)
            return;

        remainingTime -= 1f;

        if (remainingTime < 0)
        {
            remainingTime = 0;
            CancelInvoke(nameof(UpdateTimer));
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        OnTimerTicked?.Invoke(minutes, seconds);
    }
}
