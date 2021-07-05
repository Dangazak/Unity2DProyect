using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores audio clips that can be called from other scripts
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip gameOverMusic, jumpSound, lootBoxSound, coinSound, clickSound; //mainMenuMusic, gameMusic, 
    [SerializeField] float minPitch, maxPitch;//, speedToPitchRatio
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
        musicAudioSource.pitch = 1;
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
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }
    public void UnpauseMusic()
    {
        musicAudioSource.UnPause();
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
