using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    /// <summary>
    /// Stores the value that the object to move by every frame
    /// </summary>
    Vector3 newPos;

    /// <summary>
    /// int ref to the lane 
    /// </summary>
    public int LaneID {  get; set; }

    /// <summary>
    /// Sets the speed and direction for the object to move each frame adjusted by deltaTime
    /// </summary>
    /// <param name="speed">The value the object will move on the x axis every frame</param>
    /// <param name="dir">The direction on the x axis that the object will move (should be a value of 1 or -1)</param>
    public void SetSpeed(float speed, int dir)
    {
        newPos.x = dir * speed;
        if (dir > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += newPos * Time.deltaTime;
    }
}
