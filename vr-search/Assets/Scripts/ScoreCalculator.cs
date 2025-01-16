using UnityEngine;
using System;

public class ScoreCalculator : MonoBehaviour
{
    public event Action<int> OnFinalScoreCalculated;
    public bool isStillCalculatingScore = true;
    public int score = 0;

    public void IncreaseScore(int toAdd)
    {
        score += toAdd;
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponentInParent<ScoreItem>();
        Debug.Log(item);
        if (item == false || isStillCalculatingScore == false)
            return;

        if (item.isCollisionTriggered == false && isStillCalculatingScore == true)
        {
            IncreaseScore(item.ItemScore);
            item.TriggerCollision();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var item = other.GetComponentInParent<ScoreItem>();

        if (item == false || isStillCalculatingScore == false)
            return;

        if (item.isCollisionTriggered == true || isStillCalculatingScore == true)
        {
            IncreaseScore(-item.ItemScore);
            item.TriggerCollision();
        }
    }

    public void CalculateFinalScore()
    {
        Debug.Log("correct final score button pressed");
        isStillCalculatingScore = false;
        OnFinalScoreCalculated?.Invoke(score);
    }
}
