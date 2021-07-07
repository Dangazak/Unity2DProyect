using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys obstacles and other objects when they get out of the camera view
public class ObjectDestroyer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
