using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPush : MonoBehaviour {
    public int shootingMode;
    public Collider2D areaLeft;
    public Collider2D areaMid;
    public Collider2D areaRight;
    private void Start()
    {
        shootingMode = GameObject.FindWithTag("Shooter").GetComponent<Shooting>().switching_bullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            if(shootingMode==2)
            {
                Debug.Log("Rotating");
                collision.transform.Rotate(0, 0, 90);
                Destroy(gameObject);
            }
            if (shootingMode == 3)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
