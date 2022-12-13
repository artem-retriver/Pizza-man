using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerController : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    private BikerMoveble bikerMoveble;

    private bool isStart = false;

    private void Start()
    {
        isStart = true;
        bikerMoveble = GetComponent<BikerMoveble>();
    }
    private void Update()
    {
        if (isStart == true)
        {
            bikerMoveble.InputHandler();
            bikerMoveble.Movebale();
        }
    }

    public void FixedUpdate()
    {
        if(isStart == true)
        {
            bikerMoveble.Move();
        }
    }
}
