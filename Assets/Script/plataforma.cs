using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{

    Transform inicial;
    // Start is called before the first frame update
    void Start()
    {
        inicial = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vetor = new Vector3();
        vetor.z = 1;
        if (transform == inicial)
		{
            for (int i = 0; i < 10; i++)
            {
               

                transform.position += vetor;

            }
        }
        if(transform.position.z == (inicial.position.z))
		{
            for (int i = 0; i < 10; i++)
            {


                transform.position -= vetor;

            }
        }
        
       
    }
}
