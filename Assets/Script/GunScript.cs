using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    //Variaveis
    public float damage = 20;
    public float range = 100;
    public float shootImpactForce = 30f;


    public float fireRate = 35f;
    private float currentFireRateTime;
    private float nextTimeToFire = 0f;


    public Transform initialShootPosition;
    public Transform playerDirection;

    public LayerMask targetLayer;

    public AudioSource shootSound;


    public ParticleSystem muzleFlash;
    public GameObject impactEffect;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 2;
    private float currentReloadTime;


    public Text debugText; 
    //Metodos
    void Start()
    {

        currentAmmo = maxAmmo;
        currentFireRateTime = fireRate;
        currentReloadTime = reloadTime;
        
    }

   
    void Update()
    {

        //shooting

        debugText.text= currentAmmo+"/"+maxAmmo; 
       
				
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
		{
           
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
            currentFireRateTime = fireRate;
            currentAmmo--;

        }
        if(currentAmmo <= 0)
		{
            currentReloadTime -= Time.deltaTime;
            if(currentReloadTime <= 0)
			{
                currentAmmo = maxAmmo;
                currentReloadTime = reloadTime;
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
