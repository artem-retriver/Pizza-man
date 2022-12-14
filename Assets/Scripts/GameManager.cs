using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public GameObject[] carPrefabs;
    public GameObject[] pizzaPrefabs;
    public GameObject[] pizzaBuyPrefabs;

    public List<GameObject> activePizza = new List<GameObject>();
    public List<GameObject> activePizzaBuy = new List<GameObject>();
    public List<GameObject> activeCars = new List<GameObject>();
    public List<GameObject> activeRoads = new List<GameObject>();

    public List<Vector3> randomPosBuy = new List<Vector3>();
    public List<Vector3> randomPosition = new List<Vector3>();

    [SerializeField] public BikerMoveble moveble;
    [SerializeField] public BikerController controller;
    [SerializeField] public Transform biker;
    [Header("Texts:")]
    [SerializeField] public TextMeshProUGUI textSpeed;
    [SerializeField] public TextMeshProUGUI textPizza;
    [SerializeField] public TextMeshProUGUI textOrder;

    public GameObject currentPizzaBuy;

    private float spawnRoad = 0;
    private float lenghtRoad = 320;
    private int startRoad = 2;
    private int startCar = 15;
    private int startPizza = 25;
    private int posRandomZCars = 20;
    private int posRandomZPizza = 20;
    private int posRandomZPizzaBuy = 100;

    private void Start()
    {
        for (int i = 0; i < startRoad; i++)
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
        }

        for (int i = 0; i < startCar; i++)
        {
            SpawnCars(Random.Range(0, carPrefabs.Length));
        }

        for (int i = 0; i < startPizza; i++)
        {
            SpawnPizza(Random.Range(0, pizzaPrefabs.Length));
        }

        SpawnPizzaBuy(0);
    }

    private void Update()
    {
        textSpeed.text = moveble.speed.ToString();
        textPizza.text = controller.pizzaCount.ToString();
        textPizza.text += "/20";
        textOrder.text = controller.pizzaBuy.ToString();
        textOrder.text += "/50";

        if (biker.transform.position.z - 310 > spawnRoad - (startRoad * lenghtRoad))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }

        for (int i = 0; i < activeCars.Count; i++)
        {
            if (biker.transform.position.z - 10 > activeCars[i].transform.position.z)
            {
                {
                    SpawnCars(Random.Range(0, carPrefabs.Length));
                    DeleteCars(activeCars[i]);
                    activeCars.RemoveAt(i);
                }
            }
        }

        for (int i = 0; i < activePizza.Count; i++)
        {
            if (biker.transform.position.z >= activePizza[i].transform.position.z)
            {
                {
                    SpawnPizza(Random.Range(0, pizzaPrefabs.Length));
                    DeleteCars(activePizza[i]);
                    activePizza.RemoveAt(i);
                }
            }
        }

        if (biker.transform.position.z + 0.5 >= activePizzaBuy[0].transform.position.z)
        {
            SpawnPizzaBuy(0);
            DeletePizzaBuy(activePizzaBuy[0]);
            activePizzaBuy.RemoveAt(0);
        }
    }

    public void SpawnCars(int carIndex)
    {
        var posRandomX = randomPosition[Random.Range(0, randomPosition.Count)];
        
        GameObject nextCar = Instantiate(carPrefabs[carIndex], posRandomX + transform.forward * posRandomZCars, transform.rotation);
        activeCars.Add(nextCar);
        posRandomZCars += 20;
    }

    public void SpawnRoad(int gameObjectIndex)
    {
        GameObject nextRoad = Instantiate(roadPrefabs[gameObjectIndex], transform.forward * spawnRoad, transform.rotation);
        activeRoads.Add(nextRoad);
        spawnRoad += lenghtRoad;
    }

    public void SpawnPizzaBuy(int pizzaBuyIndex)
    {
        var posRandomX = randomPosBuy[Random.Range(0, randomPosBuy.Count)];

        GameObject nextPizzaBuy = Instantiate(pizzaBuyPrefabs[pizzaBuyIndex], posRandomX + transform.forward * posRandomZPizzaBuy, transform.rotation);
        activePizzaBuy.Add(nextPizzaBuy);
        posRandomZPizzaBuy += 100;

        currentPizzaBuy = nextPizzaBuy;
        return;
    }

    public void SpawnPizza(int pizzaIndex)
    {
        var posRandomX = randomPosition[Random.Range(0, randomPosition.Count)];
        posRandomX.y = 2;

        GameObject nextPizza = Instantiate(pizzaPrefabs[pizzaIndex], posRandomX + transform.forward * posRandomZPizza, transform.rotation);
        activePizza.Add(nextPizza);
        posRandomZPizza += 10;
    }

    public void DeletePizza(GameObject curPiz)
    {
        Destroy(curPiz);
    }

    public void DeletePizzaBuy(GameObject curPizBuy)
    {
        Destroy(curPizBuy);
    }

    public void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    public void DeleteCars(GameObject curCar)
    {
        Destroy(curCar);
    }
}
