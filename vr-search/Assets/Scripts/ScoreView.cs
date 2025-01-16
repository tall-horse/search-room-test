using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private ScoreCalculator scoreCalculator;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
        }

        scoreCalculator = FindFirstObjectByType<ScoreCalculator>();
        if (scoreCalculator == null)
        {
            Debug.LogError("ScoreCalculator not found in the scene.");
        }
    }

    void Start()
    {
        if (scoreCalculator != null)
        {
            scoreCalculator.OnFinalScoreCalculated += DisplayScore;
            Debug.Log("Subscribed to OnFinalScoreCalculated.");
        }
        else
        {
            Debug.LogError("Cannot subscribe because ScoreCalculator is null.");
        }
    }

    private void DisplayScore(int scoreToDisplay)
    {
        Debug.Log("DisplayScore method called.");
        scoreText.text = $"Your score is {scoreToDisplay}";
    }

    private void OnDestroy()
    {
        if (scoreCalculator != null)
        {
            scoreCalculator.OnFinalScoreCalculated -= DisplayScore;
        }
    }
}
