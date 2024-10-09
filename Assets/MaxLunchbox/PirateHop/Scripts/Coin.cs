using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("CoinTriggered");
        if (collision.CompareTag("Player"))
        {
            //print("Triggered by player");
            gameObject.transform.parent = collision.transform.Find("CoinSocket").transform; // attach coin to player
        }
    }

    public void RemoveCoin()
    {
        Destroy(gameObject);
    }
}
