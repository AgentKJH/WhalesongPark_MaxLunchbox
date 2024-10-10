using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    [SerializeField] Transform CoinSpawnLocation;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] PirateHop pirateHopMiniGameClass;
    [SerializeField] int PlayerNumber;

    private GameObject SpawnedCoin;

    void SpawnCoin()
    {
        print("Spawn Coin");
        SpawnedCoin = Instantiate(CoinPrefab, CoinSpawnLocation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Triggered On Low Beach");
        if (collision.CompareTag("Coin"))
        {
            //print("CoinOnLowBeach");
            //SpawnedCoin =  Instantiate(CoinPrefab, CoinSpawnLocation);
            //print(SpawnedCoin.name);
            SpawnCoin();
            Destroy(collision.gameObject);
            
            //pirateHopMiniGameClass.AddCoinScore(PlayerNumber - 1); to increase Score
        }
    }
}
