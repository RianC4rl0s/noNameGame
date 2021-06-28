using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variaveis
    /*
    public GameObject bulletSpawnPoint;
    public GameObject bullet;


    
    */


    public float waitTime = 1f;

    public Camera viewCamera;
    private PlayerController controller;


    public float moveSpeed = 10;
    private float speed;
    public float sprintTime = 4;
    private float currentSprintTime;

    Animator animator;


    private Vector3 axisVector;
    private Vector3 lookedAtPoint;
   
    Vector3 lastPosition;
    private Vector3 mousePosition;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        speed = moveSpeed;
        controller = GetComponent<PlayerController>();

        currentSprintTime = sprintTime;
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



        if (Input.GetKey(KeyCode.LeftShift) && currentSprintTime  > 0)
        {
            speed = moveSpeed * 2;
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
            currentSprintTime -= Time.deltaTime;
        }
        else
        {
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
            //Reset Speed
            speed = moveSpeed;
            currentSprintTime = sprintTime;
        }
       
       

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

         

        }
       

        animator.SetFloat("Vertical", forwardBackwardsMagnitude);
        animator.SetFloat("Horizontal", rightLeftMagnitude);
        animator.SetLayerWeight(1, 0);
    }
    /*
    void shoot()
    {

        Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
    }
    */
}

