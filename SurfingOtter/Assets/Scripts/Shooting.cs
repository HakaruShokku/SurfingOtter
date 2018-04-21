using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Transform gunBarrel;         // To hold the transform of the empty object, gun barrel
    public Rigidbody2D bulletPush;      // To hold the prefab of the push bullet
    public Rigidbody2D bulletRotate;    // To hold the prefab of the rotate bullet
    public Rigidbody2D bulletDestroy;   // To hold 
    public Text change_bullet;
    public int switching_bullet;

    private Rigidbody2D bulletInstance;

    // Use this for initialization
    void Start()
    {
        switching_bullet = 1;
        change_bullet.text = "Bullet Push";
    }

    // Update is called once per frame
    void Update()
    {
        ArmRotation();

        if (Input.GetKeyDown(KeyCode.F))
        {
            switching_bullet++;
            if (switching_bullet > 3)
            {
                switching_bullet = 1;
            }

            if (switching_bullet == 1)
            {
                change_bullet.text = "Bullet Push";
            }
            if (switching_bullet == 2)
            {
                change_bullet.text = "Bullet Rotate";
            }
            if (switching_bullet == 3)
            {
                change_bullet.text = "Bullet Destroy";
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    /// <summary>
    /// This function will shoot the different types of bullets
    /// </summary>
    void ShootBullet()
    {
        if (switching_bullet == 1)
        {
            bulletInstance = Instantiate(bulletPush, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
        if (switching_bullet == 2)
        {
            bulletInstance = Instantiate(bulletRotate, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
        if (switching_bullet == 3)
        {
            bulletInstance = Instantiate(bulletDestroy, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
    }

    void ArmRotation()
    {
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        Vector3 direction = mouseInWorld - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        if (rotation.z < 1f && rotation.z > -.1)
        {
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }
}
