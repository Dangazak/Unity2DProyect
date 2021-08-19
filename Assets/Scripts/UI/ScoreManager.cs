using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI and score manager
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int score;
    [SerializeField] Text scoreText, recordText, gameOverScoreText, gameOverRecordText;
    [SerializeField] GameObject gameOverPanel, gameUIPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void CheckRecord()
    {
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
        }
        gameOverScoreText.text = score.ToString();
        gameOverRecordText.text = PlayerPrefs.GetInt("Record").ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
