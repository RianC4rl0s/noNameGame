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


	public float meleeDamage = 50;
	public float meleeForce = 70;

	public GameObject playerRota;

	public float waitTime = 1f;
	private float sleep;


	public Light shootLight;



	//melee
	public Transform atackPoint;
	public float atackRange = 0.5f;
	public LayerMask enemyLayer;


	//Animations
	Animator animator;
	//Metodos

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
		atualFireRate = fireRate;
		sleep = waitTime;
	}

	private void Update()
	{
		//shooting

		//atualFireRate -= Time.deltaTime;
		/*if (Input.GetButton("Fire1")){
			
			if(atualFireRate <= 0)
			{
				shoot();
				atualFireRate = fireRate;
			}
						
			
		}*/
		if(health <= 0)
		{
			die();
		}

		//MeleeCombat
		if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetTrigger("kick");
			Atack();

			Debug.Log("Apertou");
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

	void Atack()
	{
		Collider[] hitEnemies = Physics.OverlapSphere(atackPoint.position,atackRange, enemyLayer);


		foreach (Collider enemy in hitEnemies)
		{
			Debug.Log("Hit" + enemy.name);
			enemy.GetComponent<Enemy2Script>().TakeDamage(meleeDamage);
			enemy.GetComponent<Rigidbody>().AddForce(atackPoint.position*meleeForce);
		}

	}
	private void OnDrawGizmosSelected()
	{
		if (atackPoint == null)
			return;
		Gizmos.DrawWireSphere(atackPoint.position, atackRange);
	}
}
