using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
    
    private GameObject player;
    private Vector3 playerStartPosition;
    private int lives;

    public AudioSource deathsound;
    public bool death;
    public float yHitZone;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosition = player.transform.position;
        death = false;
        lives = 3;
        deathsound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.y < 134f)
        {
            death = true;
            deathsound.Play();
        }
        if (death)
        {
            if (lives > 0)
            {
                lives--;
                player.transform.position = playerStartPosition;
                death = false;
            }
        }
        if (lives == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
	}
}
