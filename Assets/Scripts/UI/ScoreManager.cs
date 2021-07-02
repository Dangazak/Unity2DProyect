using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int score;
    [SerializeField] Text scoreText, recordText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
    }

    public void AddScore(int n)
    {
        score += n;
        scoreText.text = score.ToString();
    }

    public void CheckRecord()
    {
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
        }
    }
}
