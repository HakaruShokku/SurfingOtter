using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBlocks : MonoBehaviour {

    public Transform[] spawn_locations; // To hold the different spawn locations
    public GameObject[] boxes;          // To hold the prefabs of the boxes

    private GameObject player;          // To hold the game object of the player, later to get the transform
    private GameObject boxInstance;     // To hold the instance of the first box
    private Vector3 box_placement;      // To hold the placement location of the bear
    private int current_spawn_location; // To hold a random number for the spawn location within length of the array spawn_locations
    private int randomBox;              // To hold an integer for the random box
    private int spawn_box_timer;        // To hold an the counter until next box spawns.


    [SerializeField]
    private float secondsToSpawn;

    // Use this for initialization
    void Start()
    {
        spawn_box_timer = (int)(60*secondsToSpawn);  // set timer to 3 seconds
        player = GameObject.FindGameObjectWithTag("Player");    // set player to the tag of "Player"
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, transform.position.y);    // Follow the player by it's X axis

        spawn_box_timer--;    // Spawn box cyle start

        // once spawn_box_timer reaches 0, then spawn a new box.
        if(spawn_box_timer <= 0)
        {
            SpawnBox();             // spawn box
            spawn_box_timer = (int)(60*secondsToSpawn);  // return timer of the spawn_box_timer
        }
    }
    
    /// <summary>
    /// This function will spawn a box
    /// </summary>
    void SpawnBox()
    {
        randomBox = Random.Range(0, boxes.Length);                                          // Get a random int for the box
        current_spawn_location = Random.Range(0, spawn_locations.Length);                   // Get a random int for the spawn location
        box_placement = spawn_locations[current_spawn_location].position;                   // initialize the spawn location position
        boxInstance = Instantiate(boxes[randomBox], box_placement, Quaternion.identity);    // Instantiate box, and save in boxInstance.
    }
}
