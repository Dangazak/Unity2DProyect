using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpReward : MonoBehaviour, IRewards
{
    [SerializeField] float speedChangeAmount;
    GameManager gameManager;
    public void ActivateReward()
    {
        gameManager = GameManager.Instance;
        gameManager.SpeedChange(speedChangeAmount);
        if (speedChangeAmount > 0)
            RewardTextManager.instance.ActivateText("Speed up!");
        else if (speedChangeAmount < 0)
            RewardTextManager.instance.ActivateText("Slow down!");
    }
}
