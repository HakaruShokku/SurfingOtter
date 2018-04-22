using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
    
    private GameObject player;
    private Vector2 playerStartPosition;
    private bool death;
    private int lives;
    
    public float yHitZone;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosition = player.transform.position;
        death = false;
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.y < 134f)
        {
            death = true;
        }
        if (death)
        {
            if(lives > 0)
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

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Collider2D collider = collision.collider;

        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collider.bounds.center;

        if (collision.collider.tag == "Block")
        {

            float speedOfBlock = collision.relativeVelocity.magnitude;

            if (contactPoint.y + yHitZone < center.y && speedOfBlock > 2)
            {
                death = true;
            }
        }
    }

}
