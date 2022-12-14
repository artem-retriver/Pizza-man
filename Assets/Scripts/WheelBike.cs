using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBike : MonoBehaviour
{
    public float speedWheel = 10;
    public bool isStart = false;

    private void Start()
    {
        isStart = true;
    }

    private void Update()
    {
        if(isStart == true)
        {
            Vector3 newRotation = new Vector3(speedWheel, 0, 0);
            transform.eulerAngles = newRotation;
            speedWheel += 1;
        }
    }
}
