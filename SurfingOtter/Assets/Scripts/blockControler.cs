using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockControler : MonoBehaviour {

    public AudioSource blockhitsound;

    // Use this for initialization
    void Start () {

        blockhitsound = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RBullet")
        {
            transform.Rotate(0, 0, 90, Space.Self);
            blockhitsound.Play();
        }
        if (collision.gameObject.tag == "PBullet")
        {
            //Push Bullet
            blockhitsound.Play();
        }
        if (collision.gameObject.tag == "DBullet")
        {
            Destroy(this.gameObject);
            blockhitsound.Play();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
