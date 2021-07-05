using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.PLAYER_LAYER)
        {
            ScoreManager.instance.AddScore(value);
            AudioManager.instance.PlayCoinSound();
            Destroy(gameObject);
        }
    }
}
