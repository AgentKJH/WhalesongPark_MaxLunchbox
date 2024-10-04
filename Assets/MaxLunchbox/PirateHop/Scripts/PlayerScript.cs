using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject h_PlayerCreatures;

    private bool ableToMove = true;
    private GameObject currentTile = null;

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
        // Up
        if (direction.y > 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.up, raycastDistance, layerMask);
            MoveToTile(FindTileToHopTo(hit), direction);        
        }
        //Down
        else if (direction.y < 0)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.down, raycastDistance, layerMask);
            MoveToTile(FindTileToHopTo(hit), direction);
        }
    }

    // Needs to be held outside of the MoveTile function to make it clean.
    private int laneToJumpTo = 0; 

    // Move the player to the inputed gameobjects position if it exists if not it moves the player to the next lane in specified direction
    private void MoveToTile(GameObject tileToHopTo, Vector2 direction)
    {
        // If a tile is found to jump
        if (tileToHopTo!= null)
        {
            // Moves player to the tile
            gameObject.transform.position = tileToHopTo.transform.position;

            // Parents to ships
            gameObject.transform.SetParent(tileToHopTo.transform, true);
            
            return;
        }

        // If no tile is found
        if (direction.y > 0)
        {
            laneToJumpTo = currentTile.GetComponent<ObjectMovement>().LaneID + 1;   
        }
        else if (direction.y < 0)
        {
            laneToJumpTo = currentTile.GetComponent<ObjectMovement>().LaneID - 1;
        }

        Transform laneToJumpToLocation = LaneManager.Instance.LaneLocations[laneToJumpTo];

        // Moves player to the next lane in specifed direction on the Y axis
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, laneToJumpToLocation.position.y, gameObject.transform.position.z);

        // Parents to ships
        gameObject.transform.SetParent(h_PlayerCreatures.transform, true);

        // Death

    }

    // Returns the closest tile that the player can move to from the inputed array
    private GameObject FindTileToHopTo(RaycastHit2D[] hitInfo)
    {
        int numberOfTiles = hitInfo.Length;
        print(numberOfTiles);

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (currentTile != null)
            {
                // If the lane ID of the raycasted tile is the same as the current tile then skip itteration of loop
                if (hitInfo[i].rigidbody.GetComponent<ObjectMovement>().LaneID == currentTile.GetComponent<ObjectMovement>().LaneID) continue;
            }

            Vector2 playerLocation = gameObject.transform.position;
            Vector2 currentTileLocation = hitInfo[i].rigidbody.transform.position;

            float distanceFromPlayer = Vector2.Distance(playerLocation, currentTileLocation);
    
            currentTile = hitInfo[i].rigidbody.gameObject;

            return hitInfo[i].rigidbody.gameObject;   
        }

        // If no tile found return nothing
        return null;
    }
}
