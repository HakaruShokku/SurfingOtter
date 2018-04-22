using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

    public Image playerHealthBar;

    public int health;
    private int currHealth;
    private float healthPerFillAmt;

    public float yHitZone;

	// Use this for initialization
	void Start () {
        playerHealthBar.fillAmount = 1f;
        currHealth = health;
        healthPerFillAmt = 1f/health;
	}
	
	// Update is called once per frame
	void Update () {
		if(health >= 0)
        {
            playerHealthBar.fillAmount = health * healthPerFillAmt;
        }
	}

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            playerHealthBar.fillAmount = 0;
        }
        else
        {
            playerHealthBar.fillAmount = health * healthPerFillAmt;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {       

        Collider2D collider = collision.collider;

        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collider.bounds.center;        

        if(collision.collider.tag == "Block")
        {
            
            float speedOfBlock = collision.relativeVelocity.magnitude;

            if (contactPoint.y+yHitZone < center.y && speedOfBlock > 2)
            {
                Debug.Log("Player was hit at " + contactPoint.y);
                takeDamage(2);
            }
        }
    }
}
