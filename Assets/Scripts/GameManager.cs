using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public GameObject[] carPrefabs;
    public List<GameObject> activeCars = new List<GameObject>();
    public List<GameObject> activeRoads = new List<GameObject>();
    public List<Vector3> randomPosition = new List<Vector3>();
    [SerializeField] public BikerMoveble moveble;
    [SerializeField] public Transform biker;
    [Header("Texts:")]
    [SerializeField] public TextMeshProUGUI textSpeed;

    private float spawnRoad = 0;
    private float spawnCar = 0;
    private float lenghtCar = 10;
    private float lenghtRoad = 320;
    private int startRoad = 2;
    private int startCar = 15;
    private int posRandomZ = 20;

    private void Start()
    {
        for (int i = 0; i < startRoad; i++)
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
        }

       // if()
        for (int i = 0; i < startCar; i++)
        {
            SpawnCars(Random.Range(0, carPrefabs.Length));
        }
    }

    private void Update()
    {
        textSpeed.text = moveble.speed.ToString();

        if(biker.transform.position.z - 310 > spawnRoad - (startRoad * lenghtRoad))
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
    }

    public void SpawnCars(int carIndex)
    {
        var posRandomX = randomPosition[Random.Range(0, randomPosition.Count)];
        
        GameObject nextCar = Instantiate(carPrefabs[carIndex], posRandomX + transform.forward * posRandomZ, transform.rotation);
        activeCars.Add(nextCar);
        posRandomZ += 20;
    }

    public void SpawnRoad(int gameObjectIndex)
    {
        GameObject nextRoad = Instantiate(roadPrefabs[gameObjectIndex], transform.forward * spawnRoad, transform.rotation);
        activeRoads.Add(nextRoad);
        spawnRoad += lenghtRoad;
    }

    public void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    public void DeleteCars(GameObject curCar)
    {
        Destroy(curCar);
        //activeCars.RemoveAt(0);
    }
}
