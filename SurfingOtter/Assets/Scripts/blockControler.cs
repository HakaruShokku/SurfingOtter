using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RBullet")
        {
            transform.Rotate(0, 0, 90, Space.Self);
        }
        if (collision.gameObject.tag == "PBullet")
        {
            //Push Bullet
        }
        if (collision.gameObject.tag == "DBullet")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
