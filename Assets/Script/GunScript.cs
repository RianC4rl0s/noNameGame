using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //Variaveis
    public float damage = 20;
    public float range = 100;
    public float shootImpactForce = 30f;


    public float fireRate = 0.5f;
    private float currentFireRateTime;


    public Transform initialShootPosition;
    public Transform playerDirection;

    public LayerMask targetLayer;

    public AudioSource shootSound;


    public ParticleSystem muzleFlash;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentFireRateTime = fireRate;
        
    }

    // Update is called once per frame
    void Update()
    {

        //shooting

       
				
        if (Input.GetButton("Fire1"))
		{
            if (currentFireRateTime <= 0)
            {
               
                shoot();
                currentFireRateTime = fireRate;
            }
        }
        currentFireRateTime -= Time.deltaTime;
    }
	void shoot()
	{
        shootSound.Play();
        muzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(initialShootPosition.position,playerDirection.forward , out hit, range))
		{
            Debug.Log(hit.transform.name);
			
            Enemy2Script enemy = hit.transform.GetComponent<Enemy2Script>();
            if(enemy != null)
			{
                enemy.TakeDamage(damage);
			}

            if(hit.rigidbody != null)
			{
                hit.rigidbody.AddForce(-hit.normal * shootImpactForce);
			}
           GameObject impactGO= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,2f);

		}
    }
}
