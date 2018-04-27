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
        if(shootingMode==1)
        {
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            if (shootingMode == 1)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 1000);
                //foreach(ContactPoint contact in collision.contacts)
                //{
                //    if(contact.thisCollider==areaLeft)
                //    {
                //        collision.rigidbody.AddForce(collision.transform.right * 100);
                //    }
                //}
                //Vector2 direction = transform.InverseTransformPoint(collision.transform.position); //this helps us find which direction the object collided from

                //if (direction.x > 0f)
                //{
                //    Debug.Log("The object collided with the right side of the ball!");
                //}
                //else if (direction.x < 0f)
                //{
                //    Debug.Log("The object collided with the left side of the ball!");
                //}

                //Destroy(gameObject);
            }

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
