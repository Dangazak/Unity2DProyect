using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour
{
    Renderer rendererTarget;
    [SerializeField] float parallaxVelocity;
    [SerializeField] bool stop;
    float timePassed;
    GameManager gameManager;

    void Start()
    {
        rendererTarget = GetComponent<Renderer>();
        gameManager = GameManager.Instance;
    }


    void Update()
    {
        if (!stop)
        {
            timePassed += Time.deltaTime;
            rendererTarget.material.mainTextureOffset = new Vector2(timePassed * parallaxVelocity, 0);
        }
    }
}
