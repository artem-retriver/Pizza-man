using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool isTouch = false;
    Vector3 currentPos = new Vector3();
    //Vector3 currentPosY = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        MoveCar();
    }

    // Update is called once per frame
    public void Update()
    {
        if(isTouch == true)
        {
            isTouch = false;
            Vector3 newPos = transform.position;
            newPos.z = Random.Range(120, 140);
            transform.position = newPos;
            //currentPos.z = 140;
            //Debug.Log("1");
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
            //currentPos = cars.transform.position;
            //transform.position = currentPos;
            isTouch = true;
            cars.isTouch = false ;
        }
    }
}
