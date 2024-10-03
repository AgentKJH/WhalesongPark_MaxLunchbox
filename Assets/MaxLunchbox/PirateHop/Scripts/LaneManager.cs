using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SO_LaneData[] laneDataSets;

    [Header("Lane")]
    [SerializeField] Transform[] LaneLocations;

    /// <summary>
    /// An array of lists that stores the objects spawned in each lane 
    /// </summary>
    List<GameObject>[] laneObjects;

    int difficultyIndex = 0;

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
        laneObjects = new List<GameObject>[LaneLocations.Length - 1]; // define the number lanes for the array, adjusted by -1 for 0 based
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLaneObject(int LaneIndex)
    {
        // randomly select an object to spawn from the related lane data
        GameObject objectToSpawn = laneDataSets[LaneIndex].laneObjects[Random.Range(0, laneDataSets.Length-1)];

        // spawn object on lane and add to the related list
        laneObjects[LaneIndex].Add(Instantiate(objectToSpawn, LaneLocations[LaneIndex]));

        // Set movement speed and direction for spawned object
        laneObjects[LaneIndex].ElementAt(LaneIndex).gameObject.GetComponent<ObjectMovement>().SetSpeed(laneDataSets[LaneIndex].LaneSpeeds[difficultyIndex], laneDataSets[LaneIndex].laneDirection);
    }
}