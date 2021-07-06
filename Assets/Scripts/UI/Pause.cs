using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel, gameUIPanel;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gameUIPanel.SetActive(false);
        AudioManager.instance.PauseMusic();
    }

    public void UnPauseGame()
    {
        Time.timeScale = gameManager.gameSpeed;
        pausePanel.SetActive(false);
        gameUIPanel.SetActive(true);
        AudioManager.instance.UnpauseMusic();
    }
}
