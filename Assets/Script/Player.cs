using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Variaveis
	public float health = 100;


	public AudioSource shootSound;
	public GameObject bulletSpawnPoint;
	public GameObject bullet;
	public float fireRate = 0.5f;
	private float atualFireRate;



	public GameObject playerRota;

	public float waitTime = 1f;
	private float sleep;


	public Light shootLight;

	//Metodos

	private void Start()
	{
		atualFireRate = fireRate;
		sleep = waitTime;
	}

	private void Update()
	{
		//shooting

		atualFireRate -= Time.deltaTime;
		if (Input.GetButton("Fire1")){
			
			if(atualFireRate <= 0)
			{
				shoot();
				atualFireRate = fireRate;
			}
						
			
		}
		if(health <= 0)
		{
			die();
		}

		

	}
	void shoot()
	{
		
		shootSound.Play();
		Instantiate(bullet, bulletSpawnPoint.transform.position, playerRota.transform.rotation);
	
	}
	void die()
	{
		Destroy(gameObject);
	}
}
