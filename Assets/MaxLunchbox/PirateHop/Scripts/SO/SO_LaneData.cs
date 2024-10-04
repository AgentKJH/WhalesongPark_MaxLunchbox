using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Stores data for a single lane in PirateHop
/// </summary>
[CreateAssetMenu(fileName = "LaneData", menuName = "SO/LaneData", order = 0)]
public class SO_LaneData : ScriptableObject
{
    /// <summary>
    /// An array of objects that can be spawned in this lane
    /// </summary>
    [SerializeField] public GameObject[] laneObjects;
    /// <summary>
    /// Lane movement direction multiplier (should only be 1 or -1)
    /// </summary>
    [SerializeField][Range(-1, 1)] public int laneDirection;

    [Header("Values Indexed by Difficulty")]
    /// <summary>
    /// An array of speeds for lane objects to move indexed by the difficulty level of the game
    /// </summary
    [SerializeField] public float[] LaneSpeeds;
    /// <summary>
    /// The time before spawning a new object in the lane, indexed by the difficulty level of the game
    /// </summary>
    [SerializeField] public float[] spawnIntervals;
}
