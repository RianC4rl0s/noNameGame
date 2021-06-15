using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variaveis
    /*
    public GameObject bulletSpawnPoint;
    public GameObject bullet;


    public float waitTime = 1f;
    */


    public Camera viewCamera;
    private PlayerController controller;


    public float moveSpeed = 10;
    private float speed;



    /*
    public float jumpForce = 5f;
    private float jump;
    private bool isJumping;
    public float groundCheckRadius;
     private bool isGrounded;
    public float groundDistance;
    public Transform groundCheck;
    public LayerMask whatisGrounded;
    */
    Vector3 lastPosition;
    private Vector3 mousePosition;
    void Start()
    {
        speed = moveSpeed;
        controller = GetComponent<PlayerController>();
      //  anim = GetComponent<Animator>();
        //viewCamera = Camera.main;

       // jump = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {


        //Movement


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical);
        Vector3 moveVelocity = moveInput.normalized;
        //Sprint


        if (moveInput.magnitude >= 0.1f)
        {
           /// anim.SetBool("isWalking", true);

        }
        else
        {
           // anim.SetBool("isWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 40;
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
        }
        else
        {
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
            //Reset Speed
            speed = moveSpeed;
        }

        /*
        if (Input.GetButtonDown("Jump"))
        {

            controller.Jump(jump);

        }
        */

        //Look at Cursor
        
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            mousePosition = ray.GetPoint(rayDistance);

            controller.LookAt(mousePosition);
           // Debug.Log(rayDistance);
        }

        Ray teste = new Ray(viewCamera.transform.position, transform.position);

       

        /*
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }
        */
        //shooting
      
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            if (waitTime <= 0)
            {

            }

            shoot();
        }
        */
    }
    /*
    void shoot()
    {

        Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
    }
    */
}

