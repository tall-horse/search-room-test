using TMPro;
using UnityEngine;

public class TimerView: MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private Timer timer;
    private void Awake() {
        timer = FindAnyObjectByType<Timer>();
        timerText = GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        timer.OnTimerTicked += UpdateTimerDisplay;
    }
    private void UpdateTimerDisplay(int minutes, int seconds)
    {
        timerText.text = $"{minutes}:{seconds:D2}";
    }
}
