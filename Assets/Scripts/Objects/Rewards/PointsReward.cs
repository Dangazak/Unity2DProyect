using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsReward : MonoBehaviour, IRewards
{
    [SerializeField] int minPoints, maxPoints;
    public void ActivateReward()
    {
        ScoreManager.instance.AddScore(Random.Range(minPoints, maxPoints + 1) * 100);
    }
}
