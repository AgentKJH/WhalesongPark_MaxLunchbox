using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SO_LaneData[] laneDataSets;

    [Header("Lane")]
    [SerializeField] public Transform[] LaneLocations;

    /// <summary>
    /// An array of lists that stores the objects spawned in each lane 
    /// </summary>
    List<GameObject>[] laneObjects;

    int difficultyIndex = 0;

    bool[] spawnInLanes;

    float[] laneSpawnIntervalTimers;

    /// <summary>
    /// LaneManager Singleton Instance
    /// </summary>
    public static LaneManager Instance;

    private void Awake()
    {
        if (Instance == null) // Setup Singleton, ensure there is only one
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // define the number of lanes for each array
        laneObjects = new List<GameObject>[LaneLocations.Length - 1]; // adjusted by -1 for 0 based
        spawnInLanes = new bool[LaneLocations.Length - 1];
        for (int i = 0; i < spawnInLanes.Length; i++) { spawnInLanes[i] = true; } // set spawning in each lane to true
        laneSpawnIntervalTimers = new float[LaneLocations.Length - 1];
    }

    // Update is called once per frame
    void Update()
    {
        // loop through each lane
        for (int i = 0; i < laneObjects.Length; i++)
        {
            if (spawnInLanes[i])
            {
                laneSpawnIntervalTimers[i] -= Time.deltaTime; // reduce timers
                if (laneSpawnIntervalTimers[i] <= 0)
                { 
                    SpawnLaneObject(i); // if time reaches 0 spawn an object
                    laneSpawnIntervalTimers[i] = Random.Range(laneDataSets[i].spawnIntervalsMin[difficultyIndex], laneDataSets[i].spawnIntervalsMax[difficultyIndex]); // reset interval timer based on difficulty
                }
            }
        }
    }

    void SpawnLaneObject(int LaneIndex)
    {
        // randomly select an object to spawn from the related lane data
        GameObject objectToSpawn = laneDataSets[LaneIndex].laneObjects[Random.Range(0, laneDataSets[LaneIndex].laneObjects.Length - 1)];

        // spawn object on lane and add to the related list
        GameObject objectSpawned = Instantiate(objectToSpawn, LaneLocations[LaneIndex]);
        //laneObjects[LaneIndex].Add(objectSpawned);

        // Set movement speed and direction for spawned object
        objectSpawned.GetComponent<ObjectMovement>().SetSpeed(laneDataSets[LaneIndex].LaneMinSpeeds[difficultyIndex], laneDataSets[LaneIndex].laneDirection);
        objectSpawned.GetComponent<ObjectMovement>().LaneID = LaneIndex; // set lane ID
    }
}