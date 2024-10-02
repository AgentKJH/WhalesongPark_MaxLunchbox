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
        if (ableToMove == false)
        {
            if (timeToWaitBetweenMovements >= Time.time - startTime)
            {
                ableToMove = true;
            }
        }
    }

     
    // Calls on any directional input
    // Only triggers for X Axis
    public void DirectionalInput(Vector2 direction)
    {
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

        // Checks what direction on the X axis the player is trying to move
        if (direction.y > 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.up, 5, layerMask);
            MoveToTile(FindTileToHopTo(hit));        
        }
        else if (direction.y < 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.down, 5, layerMask);
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

        ableToMove = false;
        startTime = Time.time;
        gameObject.transform.position = tileToHopTo.transform.position;
        print("Moved player");

        //Parents to ships
    }

    // Returns the closest tile that the player can move to from the inputed array
    private GameObject FindTileToHopTo(RaycastHit2D[] hitInfo)
    {
        int numberOfTiles = hitInfo.Length;

        float closestDistanceFromPlayer = float.MaxValue;

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (hitInfo[i].rigidbody.gameObject == currentTile) continue;

            Vector2 playerLocation = gameObject.transform.position;
            Vector2 currentTileLocation = hitInfo[i].rigidbody.transform.position;

            float distanceFromPlayer = Vector2.Distance(playerLocation, currentTileLocation);

            if (distanceFromPlayer < closestDistanceFromPlayer)
            {
                closestDistanceFromPlayer = distanceFromPlayer;
                currentTile = hitInfo[i].rigidbody.gameObject;
            }
        }

        return currentTile;
    }
}
