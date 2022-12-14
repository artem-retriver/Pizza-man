using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool isTouch = false;

    void Start()
    {
        MoveCar();
    }

    public void Update()
    {
        if(isTouch == true)
        {
            isTouch = false;
            Vector3 newPos = transform.position;
            newPos.z = Random.Range(120, 140);
            transform.position = newPos;
        }
    }

    public void MoveCar()
    {
        if(transform.position.x < 0)
        {
            Vector3 currentRotation = new Vector3(0, 180, 0);
            transform.eulerAngles = currentRotation;
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cars cars))
        {
            isTouch = true;
            cars.isTouch = false ;
        }
    }
}
