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

    Animator animator;


    private Vector3 axisVector;
    private Vector3 lookedAtPoint;
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
        animator = GetComponentInChildren<Animator>();
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


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical);
        Vector3 moveVelocity = moveInput.normalized;
        //Sprint


        //animation
        axisVector = new Vector3(horizontal,0,vertical);
        lookedAtPoint = mousePosition;
        UpdateAnimator();
        /*animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Horizontal", horizontal);
        */
        if (moveInput.magnitude >= 0.1f)
        {
            
            //animator.SetBool("isRunning", true);

        }
        else
        {
            //animator.SetBool("isRunning", false);
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
    private void UpdateAnimator()
    {
        float forwardBackwardsMagnitude = 0;
        float rightLeftMagnitude = 0;
        if (axisVector.magnitude > 0)
        {
            Vector3 normalizedLookingAt = lookedAtPoint - transform.position;
            normalizedLookingAt.Normalize();
            forwardBackwardsMagnitude = Mathf.Clamp(
                    Vector3.Dot(axisVector, normalizedLookingAt), -1, 1
            );

            Vector3 perpendicularLookingAt = new Vector3(
                   normalizedLookingAt.z, 0, -normalizedLookingAt.x
            );
            rightLeftMagnitude = Mathf.Clamp(
                   Vector3.Dot(axisVector, perpendicularLookingAt), -1, 1
           );

           // animator.SetBool("isRunning", true);

        }
        else
        {
            //animator.SetBool("isRunning", false);
        }

        // update the animator parameters
        animator.SetFloat("Vertical", forwardBackwardsMagnitude);
        animator.SetFloat("Horizontal", rightLeftMagnitude);
    }
    /*
    void shoot()
    {

        Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
    }
    */
}

