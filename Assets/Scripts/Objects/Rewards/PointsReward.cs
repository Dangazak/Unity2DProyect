using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsReward : MonoBehaviour, IRewards
{
    [SerializeField] int minPoints, maxPoints;
    public void ActivateReward()
    {
        int score = Random.Range(minPoints, maxPoints + 1) * 100;
        ScoreManager.instance.AddScore(score);
        RewardTextManager.instance.ActivateText(score + " points!");
    }
}
