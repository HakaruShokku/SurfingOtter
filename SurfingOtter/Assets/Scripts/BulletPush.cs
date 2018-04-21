using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPush : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Vector2 direction = transform.InverseTransformPoint(collision.transform.position); //this helps us find which direction the object collided from

            if (direction.x > 0f)
            {
                Debug.Log("The object collided with the right side of the ball!");
            }
            else if (direction.x < 0f)
            {
                Debug.Log("The object collided with the left side of the ball!");
            }

            Destroy(gameObject);
        }
    }
}
