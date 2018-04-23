using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLanded : MonoBehaviour
{

    private CircleCollider2D sc;

    private void Start()
    {
        sc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerDeath>().deathsound.Play();
            collision.gameObject.GetComponent<PlayerDeath>().death = true;
        }
        sc.enabled = false;
    }
}