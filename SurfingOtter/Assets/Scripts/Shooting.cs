using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Transform gunBarrel;         // To hold the transform of the empty object, gun barrel
    public Rigidbody2D bulletPrefab;      // To hold the prefab of the push bullet
    public Text change_bullet;
    public int switching_bullet;

    public int bulletCount;

    private Rigidbody2D bulletInstance;

    // Use this for initialization
    void Start()
    {
        switching_bullet = 1;
        change_bullet.text = "Bullet Push";

        bulletCount = 5;
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
            bulletInstance = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;

            bulletInstance.GetComponent<Collider2D>().isTrigger = false;

            bulletInstance.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 0);
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
        if (switching_bullet == 2)
        {
            bulletInstance = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;

            bulletInstance.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255);
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
        if (switching_bullet == 3)
        {
            bulletInstance = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
            bulletInstance.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
            bulletInstance.AddForce(gunBarrel.right * 1000);

            bulletInstance.GetComponent<Collider2D>().isTrigger = true;
            bulletInstance.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255);
            bulletInstance.AddForce(gunBarrel.right * 1000);
        }
        if (switching_bullet == 3&&bulletCount>0)
        {
            bulletInstance = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation) as Rigidbody2D;
            bulletInstance.GetComponent<Collider2D>().isTrigger = true;
            bulletInstance.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
            bulletInstance.AddForce(gunBarrel.right * 1000);
            bulletCount--;

        }
    }

    void ArmRotation()
    {

        // subtracting the position of the player from the mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);


        //Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        //Vector3 direction = mouseInWorld - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //if (rotation.z < 1f && rotation.z > -.1)
        //{
        //    transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        //    Debug.Log(gunBarrel.transform.position);
        //}
    }
}
