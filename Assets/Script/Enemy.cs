using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	//variaveis
	public float health = 50;
	public float waitTime = 5;
	private float currentWaitTime;

	private bool isShoot;

	private GameObject player;


	public Transform enemyPos;
	public GameObject bulletSpawnPoint;
	public GameObject bullet;
	//metodos

	private void Start()
	{
		currentWaitTime = waitTime;
		player = GameObject.FindWithTag("Player");
	}

	private void Update()
	{
		if(health <= 0)
		{
			die();
		}

		transform.LookAt(player.transform);

		if(currentWaitTime <= 0)
		{
			
			shoot();
		}
		if (isShoot && currentWaitTime < waitTime)
		{
			currentWaitTime += 1 * Time.deltaTime;
		}
		if(currentWaitTime >= waitTime)
		{
			currentWaitTime =0;
		}

	}

	void die()
	{
		Destroy(gameObject);
	}

	void shoot()
	{
		isShoot = true;
		Instantiate(bullet, bulletSpawnPoint.transform.position, enemyPos.rotation);
	}

}
