using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detects collisions with the obstacles to add their points value to the score
public class Scorer : MonoBehaviour
{
    public int baseScorePerObject;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == Constants.OBSTACLE_LAYER)
        {
            ObjectControl objectControl = other.gameObject.GetComponent<ObjectControl>();
            if (objectControl == null)
            {
                ScoreManager.instance.AddScore(baseScorePerObject);
            }
            else
            {
                ScoreManager.instance.AddScore(objectControl.scoreValue);
            }
        }
    }
}
