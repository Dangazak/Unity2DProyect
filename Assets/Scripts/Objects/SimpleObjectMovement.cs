using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMovement : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Constants.BASE_SPEED * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
