using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerMoveble : MonoBehaviour
{
    [Header("Settings:")]
    public float speed;
    public int laneSpeed;
    [SerializeField] private float jumpLenght;
    [SerializeField] private float jumpHeight;
    public FixedJoystick joystick;
    public SpineBike spineBike;

    private Vector3 verticalTargetPosition;
    private float currentLane = 1;
    private new Rigidbody rigidbody;
    private bool jumping = false;
    private float jumpStart;
    //private bool isleft = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void InputHandler()
    {
        if (SwipeController.swipeLeft)
        {
            spineBike.LeftRotation();
            ChangeLane(-5);
        }
        else if (SwipeController.swipeRight)
        {
            spineBike.RightRotation();
            ChangeLane(5f);
        }
        else if (SwipeController.swipeUp)
        {
            Jump();
        }
    }


    private void Update()
    {
        if(speed > 5)
        {
            speed -= Time.deltaTime;
        }

        if(transform.position.x == -7.5 || transform.position.x == -2.5 || transform.position.x == 2.5 || transform.position.x == 7.5)
        {
            //Debug.Log("+");
            Vector3 curRot = new(25, 0, -90);
            spineBike.transform.eulerAngles = curRot;
        }
        /*if(isleft == true)
        {
            Vector3 newRotataion = new Vector3(0, 0, 10);
            transform.eulerAngles = newRotataion;
            isleft = false;
        }else if (isleft == false)
        {
            Vector3 newRotataion = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotataion;
        }*/
    }

    public void Move()
    {
        if(joystick.Direction.x >= 0)
        {
            if(speed <= 20)
            {
                speed += joystick.Direction.x * 0.1f;
            }
        }else
        if(-(joystick.Direction.x) >= 0)
        {
            if(speed >= 5)
            {
                speed -= -joystick.Direction.x * 0.1f;
            }
            
        }

        rigidbody.velocity = Vector3.forward * speed;
    }

    public void UnMove()
    {
        rigidbody.velocity = Vector3.forward * 0;
    }

    public void Movebale()
    {
        if (jumping)
        {
            float ratio = (transform.position.z - jumpStart) / jumpLenght;
            if (ratio >= 1f)
            {
                jumping = false;
                //anim.SetBool("Jumping", false);
            }
            else
            {
                verticalTargetPosition.y = Mathf.Sin(ratio * Mathf.PI) * jumpHeight;
            }
        }
        else
        {
            verticalTargetPosition.y = Mathf.MoveTowards(verticalTargetPosition.y, 0, 5 * Time.deltaTime);
        }

        Vector3 targetPosition = new(verticalTargetPosition.x + 2.5f, verticalTargetPosition.y + 1.6f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (!jumping)
        {
            jumpStart = transform.position.z;
            //anim.SetFloat("JumpSpeed", speed / jumpLenght);
            //anim.SetBool("Jumping", true);
            jumping = true;
        }
    }

    private void ChangeLane(float direction)
    {
        float targetLane = currentLane + direction;

        if (targetLane < -12.5 || targetLane > 7.5)
            return;

        currentLane = targetLane;
        verticalTargetPosition = new Vector3((currentLane - 1), 0, 0);
    }
}
