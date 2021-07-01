using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public int scoreValue;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
