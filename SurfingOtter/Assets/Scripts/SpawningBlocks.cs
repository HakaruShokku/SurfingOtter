using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBlocks : MonoBehaviour {

    public Transform[] spawn_locations; // To hold the different spawn locations
    public GameObject[] boxes;          // To hold the prefabs of the boxes

    private List<int> current_locations = new List<int>(); // To hold a list of integers which will determine the location
    private GameObject boxInstance;     // To hold the instance of the first box
    private Vector3 box_placement;      // To hold the placement location of the bear
    private int current_spawn_location; // To hold a random number for the spawn location within length of the array spawn_locations
    private int spawn_box;              // To hold an the counter until next box spawns.

    // Use this for initialization
    void Start()
    {
        current_locations.Add(100); // just adding a integer to start, when using conatains method
        spawn_box = 180;
    }

    // Update is called once per frame
    void Update()
    {
        spawn_box--;
        if(spawn_box <= 0)
        {
            SpawnBox();
            spawn_box = 180;
        }
    }

    /// <summary>
    /// This function get's an index that isnt being used.
    /// It stores an integer into a List<int> current_locations.
    /// It makes sure to return a value that isnt within the List.
    /// </summary>
    /// <returns>
    /// An integer, from 0 - waypoints.length (0-14)
    /// </returns>
    private int GetIndex()
    {
        int index = Random.Range(0, spawn_locations.Length);  // Declare and initialize index to be a random number from 0-14 (waypoint.length)

        // while loop: Validation method that if the integer "index" is already in the List "current_locations" then,
        // try for a new random integer, until one is not located in that list.
        while (current_locations.Contains(index))
        {
            index = Random.Range(0, spawn_locations.Length);
        }

        current_locations.Add(index);   // Add integer to List

        return index;                   // Return integer
    }

    
    /// <summary>
    /// This function will spawn a box
    /// </summary>
    void SpawnBox()
    {
        int randomBox = Random.Range(0, boxes.Length);                            // Get a random int for the box
        current_spawn_location = GetIndex();
        box_placement = spawn_locations[current_spawn_location].position;
        boxInstance = Instantiate(boxes[randomBox], box_placement, Quaternion.identity);
    }
}
