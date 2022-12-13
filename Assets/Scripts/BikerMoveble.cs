using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerMoveble : MonoBehaviour
{
    [Header("Settings:")]
    [SerializeField] public float speed;
    [SerializeField] public int laneSpeed;
    [SerializeField] private float jumpLenght;
    [SerializeField] private float jumpHeight;
    [SerializeField] public FixedJoystick joystick;

    private Vector3 verticalTargetPosition;
    private float currentLane = 1;
    private new Rigidbody rigidbody;
    private bool jumping = false;
    private float jumpStart;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void InputHandler()
    {
        if (SwipeController.swipeLeft)
        {
            ChangeLane(-5);
        }
        else if (SwipeController.swipeRight)
        {
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

        Vector3 targetPosition = new Vector3(verticalTargetPosition.x + 2.5f, verticalTargetPosition.y + 0.5f, transform.position.z);
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
