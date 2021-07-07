using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the obstacles collision with the player and stores their variables
public class ObjectControl : MonoBehaviour
{
    public int scoreValue;
    public float spawnTimeDelay;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.PLAYER_LAYER && !Invulnerable.instance.isInvulnerable)
        {
            gameManager.GameOver();
        }
    }
}
