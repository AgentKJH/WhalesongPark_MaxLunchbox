using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDetection : MonoBehaviour
{
    public bool shipDetected = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            print("Ship detected entering");
            shipDetected = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            print("Ship detected leaving");
            shipDetected = false;
        }
    }
}
