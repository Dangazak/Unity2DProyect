using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScoreData : MonoBehaviour
{
    [SerializeField] Text myName;
    int currentScore;

    // Update is called once per frame
    void OnEnable()
    {
        currentScore = ScoreManager.instance.GetScore();
    }

    public void SendScore()
    {
        HighScores.UploadScore(myName.text, currentScore);
    }
}
