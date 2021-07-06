using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFrenzyReward : MonoBehaviour, IRewards
{
    public void ActivateReward()
    {
        CoinSpawner.instance.StartFrenzy();
    }
}
