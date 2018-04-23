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
    Vector3 PlayerScreenPoint;
    // Use this for initialization
    void Start() {
        armJoint = GameObject.Find("ArmJoint");
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = this.GetComponent<Animator>();
        facingRight = true;
        count = 100;
    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);

    }

    // Update is called once per frame
    void Update () {
        Debug.Log(facingRight);
        float mouse = Input.mousePosition.x;
        PlayerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(mouse);
        Debug.Log(PlayerScreenPoint.x);
        if (mouse < PlayerScreenPoint.x && facingRight == true)
        {
            facingRight = false;
            ChangeDirection();
        }
        else if(mouse > PlayerScreenPoint.x && facingRight == false)
        {
            facingRight = true;
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        Vector3 Scale = transform.localScale;
        Vector3 armScale = armJoint.transform.localScale;
        armScale.x *= -1;
        armScale.y *= -1;
        Scale.x *= -1;
        transform.localScale = Scale;
        armJoint.transform.localScale = armScale;

    }
}
