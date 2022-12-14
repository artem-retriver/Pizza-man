using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMan : MonoBehaviour
{
    void Start()
    {
        Vector3 newRotation = new Vector3(0, 180, 0);
        transform.eulerAngles = newRotation;
    }

    void Update()
    {
        if(transform.position.x == 10)
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }
    }
}
