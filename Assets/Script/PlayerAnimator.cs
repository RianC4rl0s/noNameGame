using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAnimator : MonoBehaviour
{
    public GameObject player;

    private Quaternion actuaRotation;
   // private Vector3 rotateTo;

    public Camera viewCamera;
    private Vector3 mousePosition;

    public float fireRate = 0.5f;
    private float atualFireRate;

    Animator animator;

    public Text debugDisplay;





    // Start is called before the first frame update
    void Start()
    {
        atualFireRate = fireRate;
        animator = GetComponent<Animator>();

        //actuaRotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       /* float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical);
       */

        /*
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            mousePosition = ray.GetPoint(rayDistance);
            
        }*/

       // mousePosition = Input.mousePosition;
        //Debug.Log(mousePosition.x + ";" +mousePosition.z);

        

        
        atualFireRate -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {

            if (atualFireRate <= 0)
            {
                animator.SetTrigger("shoot");
                atualFireRate = fireRate;
            }


        }
        
       // Debug.Log(actuaRotation);

        /*
        if (moveInput.magnitude >= 0.1f)
        {
            if (actuaRotation.y > 60 && actuaRotation.y < 120)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    animator.SetBool("runLeft", true);
                    animator.SetBool("isRunning", false);
                }
                else
                {
                    animator.SetBool("runLeft", false);
                    animator.SetBool("isRunning", true);
                }
                if (Input.GetAxis("Vertical") > 0)
                {
                    animator.SetBool("runRight", true);
                    animator.SetBool("isRunning", false);
                }
                else
                {
                    animator.SetBool("runRight", false);
                    animator.SetBool("isRunning", true);
                }
                if (Input.GetAxis("Horizontal") > 0)
                {
                    animator.SetBool("isRunning", true);
                    
                }
                else
                {
                    animator.SetBool("isRunning", false);
                   
                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    animator.SetBool("isRunningBack", true);
                    animator.SetBool("isRunning", false);
                }
                else
                {
                    animator.SetBool("isRunningBack", false);
                }


            }
            if (actuaRotation.y > 240 && actuaRotation.y < 300)
            {

            }
           
            // animator.SetBool("isRunning", true);
            // debugDisplay.text = "Esta correndo";
        }
        else
        {
             animator.SetBool("isRunning", false);
            //debugDisplay.text = "Esta parado";
        }
     */
        /*
        if(actuaRotation.y > 60 && actuaRotation.y< 120 )
		{
            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetBool("runLeft", true);
            }
            else
            {
                animator.SetBool("runLeft", false);
            }
            if (Input.GetAxis("Vertical") > 0)
			{
                animator.SetBool("runRight", true);
			}
			else
			{
                animator.SetBool("runRight", false);
            }
            if(Input.GetAxis("Horizontal") > 0){
                animator.SetBool("isRunning", true);
            }
			else
			{
                animator.SetBool("isRunning", false);
            }

            if(Input.GetAxis("Horizontal") < 0)
			{
                animator.SetBool("isRunningBack", true);
			}
			else
			{
                animator.SetBool("isRunningBack", false);
            }


		}
        if (actuaRotation.y >240 && actuaRotation.y < 300)
		{

		}
		if (actuaRotation.y <= 60 && )
		{

		}
        if(actuaRotation.y == 180)
		{

		}
        */


    }
}
