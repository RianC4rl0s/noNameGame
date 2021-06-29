using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardScript : MonoBehaviour
{


   // public Transform cam;
   
    void LateUpdate()
    {
        transform.LookAt(transform.position + GameObject.FindWithTag("MainCamera").transform.forward);
    }
}
