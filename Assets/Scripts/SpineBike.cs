using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineBike : MonoBehaviour
{
    public float rotWheel = 20;
    public bool isStart = false;

    public void LeftRotation()
    {
        Vector3 newRotation = new Vector3(25, 0, -70);
        transform.eulerAngles = newRotation;
    }

    public void RightRotation()
    {
        Vector3 newRotation = new Vector3(25, 0, -110);
        transform.eulerAngles = newRotation;
    }
}
