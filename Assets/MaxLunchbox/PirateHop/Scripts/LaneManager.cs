using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    GameObject[] LaneOneObjects;
    GameObject[] LaneTwoObjects;
    GameObject[] LaneThreeObjects;


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
