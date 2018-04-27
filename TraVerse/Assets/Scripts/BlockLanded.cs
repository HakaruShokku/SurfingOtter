using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLanded : MonoBehaviour
{

    private CircleCollider2D sc;
    public AudioSource landsound;
    public int count = 0;
    private void Start()
    {
        sc = GetComponent<CircleCollider2D>();
        landsound = GetComponent<AudioSource>();

        Destroy(gameObject, 180f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerDeath>().deathsound.Play();
            collision.gameObject.GetComponent<PlayerDeath>().death = true;
        }
        if (collision.gameObject.tag == "Ground" && count == 0)
        {
            landsound.Play();
            count = 1;
        }
        sc.enabled = false;
    }
}