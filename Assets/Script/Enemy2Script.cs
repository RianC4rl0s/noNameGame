using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Script : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private bool deadStatus = false;

    Animator animator;

    //melee
    public Transform atackPoint;
    public float atackRange = 0.5f;
    public LayerMask playerLayer;
    public float meleeDamage = 50;
    public float meleeForce = 70;

    public float timeBtwAtack = 5;
    private float currentTimeBtwAtack;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
        currentTimeBtwAtack = timeBtwAtack;
    }

    // Update is called once per frame
    void Update()
    {


        currentTimeBtwAtack -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
	{
     
        if(currentHealth > 0)
		{
        animator.SetTrigger("takeDamage");

		}

        currentHealth -= damage;


        if(currentHealth <= 0)
		{
            deadStatus = true;
            Die();
		}
	}
    void Die()
	{

        animator.SetTrigger("dying");
       
        Debug.Log("EnemyDie");
        
        Destroy(gameObject,4f);
	}
    public bool getDeadStatus()
	{
        return deadStatus;

	}
    public void atack()
	{
        if(currentTimeBtwAtack <= 0)
		{

            animator.SetTrigger("atack");
            Collider[] hitPlayer = Physics.OverlapSphere(atackPoint.position,atackRange,playerLayer);
	        foreach(Collider player in hitPlayer)
		    {
                Debug.Log("Enemy hit =" +player.name);
                player.GetComponent<Player>().TakeDamage(meleeDamage);
		    }
            currentTimeBtwAtack = timeBtwAtack;
		}
    }
	private void OnDrawGizmosSelected()
	{
        Gizmos.DrawWireSphere(atackPoint.position, atackRange);
	}
}
