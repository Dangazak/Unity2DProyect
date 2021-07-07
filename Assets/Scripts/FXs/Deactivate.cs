using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deactivate Objects with animation event
public class Deactivate : MonoBehaviour
{
    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
