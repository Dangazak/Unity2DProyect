using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    [SerializeField] float invulnerabilityTime, flickerTime;
    [SerializeField] GameObject[] objectsToFlicker;
    public static Invulnerable instance;
    float timePassed, timeSinceLastFlick;
    public bool isInvulnerable;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (isInvulnerable)
        {
            timePassed += Time.deltaTime;
            timeSinceLastFlick += Time.deltaTime;
            if (timePassed > invulnerabilityTime)
            {
                isInvulnerable = false;
                timePassed = 0;
                timeSinceLastFlick = 0;
                ActivateObjects();
                return;
            }
            if (timeSinceLastFlick > flickerTime)
            {
                timeSinceLastFlick -= flickerTime;
                Flick();
            }
        }
    }
    void ActivateObjects()
    {
        for (int i = 0; i < objectsToFlicker.Length; i++)
        {
            objectsToFlicker[i].SetActive(true);
        }
    }
    void Flick()
    {
        for (int i = 0; i < objectsToFlicker.Length; i++)
        {
            objectsToFlicker[i].SetActive(!objectsToFlicker[i].activeSelf);
        }
    }
    public void StartInvulnerability()
    {
        Flick();
        isInvulnerable = true;
    }
}
