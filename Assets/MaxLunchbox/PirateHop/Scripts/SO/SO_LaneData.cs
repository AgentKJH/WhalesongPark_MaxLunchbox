using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaneData", menuName = "SO/LaneData", order = 0)]
public class SO_LaneData : ScriptableObject
{
    [SerializeField] public GameObject[] laneObjects;
    /// <summary>
    /// An array of speeds for each "level" of the game
    /// </summary>
    [SerializeField] public float[] LaneSpeeds;
    /// <summary>
    /// Lane movement direction multiplier (should only be 1 or -1)
    /// </summary>
    [SerializeField] [Range(-1, 1)] public int laneDirection;
}
