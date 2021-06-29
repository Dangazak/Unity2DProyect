using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float BASE_SPEED = 2.5f;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public float gameSpeed;
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
        DontDestroyOnLoad(gameObject); //Not recomended
    }
    void Start()
    {
        gameSpeed = 1;
    }
}
