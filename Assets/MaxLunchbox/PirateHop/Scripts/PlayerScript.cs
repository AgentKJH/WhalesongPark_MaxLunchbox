using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private ShipDetection[] shipDetector; // 0 = Top, 1 = Bottem

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
    // Calls on any directional input
    // Only triggers for X Axis
    public void DirectionalInput(Vector2 direction)
    {
        // Checks if the movement input is on the X axis
        if (direction.x != 0)
        {
            Hop(direction);
        }
    }

    private void Hop(Vector2 direction)
    {
        if (direction.x > 0)
        {
            bool l_IsThereAShip = shipDetector[0].shipDetected;
        }
        else if (direction.x < 0)
        {
            bool l_IsThereAShip = shipDetector[1].shipDetected;
        }
    }

    private GameObject FindShip()
    {
        return gameObject;
    }
}
