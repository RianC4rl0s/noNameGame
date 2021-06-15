using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
	{
        currentHealth -= damage;


        if(currentHealth <= 0)
		{
            Die();
		}
	}
    void Die()
	{
        Debug.Log("EnemyDie");

        Destroy(gameObject);
	}
}
