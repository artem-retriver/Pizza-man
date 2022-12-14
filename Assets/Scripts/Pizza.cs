using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public float speedPizza = 1;

    private void Update()
    {
        OnRotationY();
    }

    public void OnRotationY()
    {
        Vector3 newRotation = new Vector3(-30, speedPizza, 0);
        transform.eulerAngles = newRotation;
        speedPizza += 1;
    }
}
