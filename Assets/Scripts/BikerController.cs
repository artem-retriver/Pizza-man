using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerController : MonoBehaviour
{
    public UIManager manager;
    public List<GameObject> countPiz = new List<GameObject>();
    //public List<GameObject> salePiz = new List<GameObject>();
    //public GameManager gameManager;
    private BikerMoveble bikerMoveble;
    //private PizzaOnBike onBike;

    //public List<Vector3> posPiz = new List<Vector3>();

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
        //onBike = GetComponent<PizzaOnBike>();
    }

    /*public void InsPiz()
    {
        for (int i = 0; i < posPiz.Count; i++)
        {

            //Debug.Log(i);
            Instantiate(countPiz[0], posPiz[i], transform.rotation);
            //activeCars.Add(nextCar);
            //countPiz[i].SetActive(false);
        }
    }*/

    private void Update()
    {
        

        if (isStart == true)
        {
            bikerMoveble.InputHandler();
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

            /*for (int i = 0; i < pizzaBuy; i++)
            {
                Instantiate(salePiz[0], upY, transform.rotation);
                upY.y += 0.02f;

                //onBike.isBike = true;
                //return;
                //countPiz[i].transform.position = gameManager.currentPizzaBuy.transform.position;
            }*/

            for (int i = 0; i < countPiz.Count; i++)
            {
                countPiz[i].SetActive(false);
            }
        }
    }

    /*public void ChangePos(Vector3 vec3)
    {
        Vector3 upY = transform.position;
        vec3 = upY;
        
        vec3.x = -10;
    }*/

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
