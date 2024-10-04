using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    private bool ableToMove = true;
    private GameObject currentTile = null;

    private float timeToWaitBetweenMovements = 1f;
    private float startTime;

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
        if (direction == new Vector2(0, 0)) ableToMove = true;

        // Checks if the movement input is on the X axis
        if (direction.y != 0)
        {
            Hop(direction);
        }
    }

    // Controls movement fucntionality
    private void Hop(Vector2 direction)
    {
        if (ableToMove == false) return;
        ableToMove = false;

        float raycastDistance = 2f;
        // Checks what direction on the X axis the player is trying to move
        if (direction.y > 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.up, raycastDistance, layerMask);
            MoveToTile(FindTileToHopTo(hit));        
        }
        else if (direction.y < 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.down, raycastDistance, layerMask);
            MoveToTile(FindTileToHopTo(hit));
        }
    }

    // Move the player to the inputed gameobjects position
    private void MoveToTile(GameObject tileToHopTo)
    {
        if (tileToHopTo == null)
        {
            Debug.LogError("Null gameobject has been passed through. No tile data to move to");
            return;
        }

        startTime = Time.time;
        gameObject.transform.position = tileToHopTo.transform.position;
        //Parents to ships
    }

    // Returns the closest tile that the player can move to from the inputed array
    private GameObject FindTileToHopTo(RaycastHit2D[] hitInfo)
    {
        int numberOfTiles = hitInfo.Length;
        print(numberOfTiles);
        float closestDistanceFromPlayer = float.MaxValue;

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (currentTile != null)
            {
                if (hitInfo[i].rigidbody.GetComponent<ObjectMovement>().LaneID == currentTile.GetComponent<ObjectMovement>().LaneID) continue;
            }

            Vector2 playerLocation = gameObject.transform.position;
            Vector2 currentTileLocation = hitInfo[i].rigidbody.transform.position;

            float distanceFromPlayer = Vector2.Distance(playerLocation, currentTileLocation);
            
            // If it finds a safe tile within an acceptable range then it will be returned
            if (hitInfo[i].rigidbody.gameObject.GetComponent<Tile>().ArrayIndex == (int)TileTypes.Safe)
            {
                if (distanceFromPlayer < 1)
                {
                    currentTile = hitInfo[i].rigidbody.gameObject;

                    return hitInfo[i].rigidbody.gameObject;
                }
            }
            
            // Finds the closest non safe tile
            if (distanceFromPlayer < closestDistanceFromPlayer)
            {
                closestDistanceFromPlayer = distanceFromPlayer;
                currentTile = hitInfo[i].rigidbody.gameObject;
            }
        }

        return currentTile;
    }
}
