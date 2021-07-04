using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores audio clips that can be called from other scripts
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip gameMusic, gameOverMusic, jumpSound, lootBoxSound, coinSound;
    [SerializeField] float minPitch, maxPitch, speedToPitchRatio;
    public static AudioManager instance;
    GameManager gameManager;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void PlayGameOverMusic()
    {
        musicAudioSource.Stop();
        musicAudioSource.PlayOneShot(gameOverMusic);
    }
    public void PlayJumpSound()
    {
        PlayClip(jumpSound);
    }
    public void PlayLootSound()
    {
        PlayClip(lootBoxSound);
    }
    public void PlayCoinSound()
    {
        PlayClip(coinSound);
    }
    public void ChangeMusicPitch()
    {
        musicAudioSource.pitch = gameManager.gameSpeed;
    }
    void PlayClip(AudioClip clipToPlay)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(clipToPlay);
    }
}
