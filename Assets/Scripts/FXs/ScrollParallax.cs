using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour
{
    Renderer rendererTarget;
    [SerializeField] float parallaxVelocity;
    [SerializeField] bool stop;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        rendererTarget = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            timePassed += Time.deltaTime;
            rendererTarget.material.mainTextureOffset = new Vector2((timePassed * parallaxVelocity), 0);
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            stop = !stop;
        }*/
    }
}
