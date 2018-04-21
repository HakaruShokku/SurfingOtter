using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    // Use this for initialization
    public int count = 100;
	void Start () {
		
	}

//ROTATE IF COLLIDES
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RBullet")
        {
            transform.Rotate(0, 0, 90, Space.Self);

        }
        if (collision.gameObject.tag == "PBullet")
        {
           //transform.Rotate(0, 0, 90, Space.Self);
            Debug.Log("PUSH");

        }
        if (collision.gameObject.tag == "DBullet")
        {
            Destroy(this.gameObject);
            Debug.Log("DEATH");

        }
    }
    // Update is called once per frame
    void Update () {

	}
}
