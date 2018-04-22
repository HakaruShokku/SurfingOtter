using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 mousePosition;
    public Rigidbody2D MyRigidbody { get; set; }
    private Animator myAnimator;
    public GameObject armJoint;
    public GameObject Player;
    public bool facingRight;
    public bool faceDirect;
    public int count;
    // Use this for initialization
    void Start() {
        armJoint = GameObject.Find("ArmJoint");
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = this.GetComponent<Animator>();
        facingRight = armJoint.GetComponent<Shooting>().facing;
        count = 100;
        
        //Player = GetComponentInChildren<>();
    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        mousePosition = Input.mousePosition;
        Debug.Log(mousePosition);
        HandleMovement(horizontal);

        //Flip();


    }

    private void Flip()
    {
        //Debug.Log("In Flip");
        if (true)
        {
            facingRight = false;
            ChangeDirection();
        }
        else
        {
            facingRight = true;
        }
    }

    public void ChangeDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        facingRight = false;
    }


    // Update is called once per frame
    void Update () {
        count--;
        if (count <= 0)
        {
            Flip();
            count = 150;
        }
        //float horizontal = Input.GetAxis("Horizontal");
        //HandleMovement(horizontal);
        // Flip();
        //if (Input.GetKey(KeyCode.D))
        //{
        //    //anim.SetBool("isWalking", true);
        //    //anim.SetBool("isShooting", false);
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //    //sr.flipX = true;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    //anim.SetBool("isWalking", true);
        //    //anim.SetBool("isShooting", false);
        //    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //    //sr.flipX = false;
        //}
        //else
        //{
        //    //anim.SetBool("isWalking", false);
        //}
    }
}
