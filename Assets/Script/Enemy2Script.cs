using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Die();
		}
	}
    void Die()
	{

        animator.SetTrigger("dying");
        Debug.Log("EnemyDie");
       
        Destroy(gameObject,4f);
	}
}
