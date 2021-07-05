using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] IRewards[] posibleRewards;
    [SerializeField] int[] chanceForEachReward;
    void ActivateReward()
    {
        int randomNumber = Random.Range(0, AddAllChances());
        int chancesChecked = 0;
        for (int i = 0; i < chanceForEachReward.Length; i++)
        {
            if (randomNumber > chancesChecked + chanceForEachReward[i])
            {
                posibleRewards[i].ActivateReward();
                return;
            }
            chancesChecked += chanceForEachReward[i];
        }
    }
    int AddAllChances()
    {
        int totalChances = 0;
        for (int i = 0; i < chanceForEachReward.Length; i++)
        {
            totalChances += chanceForEachReward[i];
        }
        return totalChances;
    }
}
