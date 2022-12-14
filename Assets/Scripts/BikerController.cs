using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerController : MonoBehaviour
{
    public UIManager manager;
    public List<GameObject> countPiz = new List<GameObject>();
    private BikerMoveble bikerMoveble;

    private bool isStart = false;
    public int pizzaCount = 0;
    public int pizzaBuy = 0;

    private void Start()
    {
        for (int i = 0; i < countPiz.Count; i++)
        {
            countPiz[i].SetActive(false);
        }

        isStart = true;
        bikerMoveble = GetComponent<BikerMoveble>();
    }

    private void Update()
    {
        if (isStart == true)
        {
            bikerMoveble.ButtonClick();
            bikerMoveble.Movebale();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cars _))
        {
            manager.ShowLoseScreen();
            isStart = false;
        }

        if (other.TryGetComponent(out Pizza _))
        {
            for (int i = 0; i < countPiz.Count; i++)
            {
                if (pizzaCount == i)
                {
                    countPiz[i].SetActive(true);
                }
            }

            if(pizzaCount < 20)
            {
                pizzaCount += 1;
            }
        }

        if(other.TryGetComponent(out PizzaBuy _))
        {
            if(pizzaBuy < 50)
            {
                pizzaBuy = pizzaBuy + pizzaCount;
                pizzaCount = 0;
            }
          
            if(pizzaBuy >= 50)
            {
                manager.ShowWinScreen();
                pizzaBuy = 50;
                isStart = false;
            }

            Vector3 upY = transform.position;
            upY.y = 2;

            for (int i = 0; i < countPiz.Count; i++)
            {
                countPiz[i].SetActive(false);
            }
        }
    }

    public void FixedUpdate()
    {
        if(isStart == true)
        {
            bikerMoveble.Move();
        }
        else
        {
            bikerMoveble.UnMove();
        }
    }
}
