using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
