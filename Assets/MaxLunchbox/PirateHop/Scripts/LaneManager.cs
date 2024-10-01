using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SO_LaneData[] laneDataSets;

    [Header("Lane")]
    [SerializeField] GameObject[] LaneMarkers;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
