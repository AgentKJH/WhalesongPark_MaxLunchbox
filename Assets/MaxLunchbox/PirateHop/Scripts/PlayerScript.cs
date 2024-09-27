using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Collider2D[] ShipDetector;

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
        if (direction.x != 0)
        {
            Hop(direction);
        }
    }

    private void Hop(Vector2 direction)
    {

    }

    private bool IsShip(Vector2 direction)
    {
        return false;
    }
}
