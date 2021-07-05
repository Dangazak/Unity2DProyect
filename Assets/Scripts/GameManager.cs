using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public float gameSpeed;
    [SerializeField] float minGameSpeed, maxGameSpeed;
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
        DontDestroyOnLoad(gameObject); //Not recomended, carefull with scene change
    }
    void Start()
    {
        Initialice();
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        //ScoreManager.instance.CheckRecord();
    }
    public void SpeedChange(float deltaSpeed)
    {
        gameSpeed += deltaSpeed;
        gameSpeed = Mathf.Clamp(gameSpeed, minGameSpeed, maxGameSpeed);
        Time.timeScale = gameSpeed;
    }
    public void Initialice()
    {
        gameSpeed = minGameSpeed;
        Time.timeScale = gameSpeed;
        //reset score
    }
}
