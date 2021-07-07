using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the "loot boxes" that activate a random reward when they are picked
public class Loot : MonoBehaviour
{
    [SerializeField] GameObject[] posibleRewards;
    [SerializeField] int[] chanceForEachReward;
    void ActivateRandomReward()
    {
        int randomNumber = Random.Range(0, AddAllChances());
        int chancesChecked = 0;
        for (int i = 0; i < chanceForEachReward.Length; i++)
        {
            if (randomNumber < chancesChecked + chanceForEachReward[i])
            {
                posibleRewards[i].GetComponent<IRewards>().ActivateReward();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.PLAYER_LAYER)
        {
            ActivateRandomReward();
            AudioManager.instance.PlayLootSound();
            Destroy(gameObject);
        }
    }
}
