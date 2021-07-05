using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpReward : IRewards
{
    [SerializeField] float speedChangeAmount;
    GameManager gameManager;
    public void ActivateReward()
    {
        gameManager = GameManager.Instance;
        gameManager.SpeedChange(speedChangeAmount);
    }
}
