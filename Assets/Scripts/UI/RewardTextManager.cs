using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardTextManager : MonoBehaviour
{
    public static RewardTextManager instance;
    [SerializeField] GameObject rewardPanel;
    [SerializeField] Text rewardText;

    private void Start()
    {
        instance = this;
    }
    public void ActivateText(string text)
    {
        rewardText.text = text;
        rewardPanel.SetActive(true);
    }
}
