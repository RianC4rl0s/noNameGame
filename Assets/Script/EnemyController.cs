using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{

    public float radius = 10f;


    Animator animator;
    Transform target;
    NavMeshAgent agent;

    Enemy2Script enemyScript;


    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
        enemyScript = GetComponent<Enemy2Script>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        isDead = enemyScript.getDeadStatus();

        if(distance <= radius && isDead== false )
		{
            agent.SetDestination(target.position);
            animator.SetBool("isRunning", true);
        }

        if(agent.remainingDistance <= agent.stoppingDistance)
		{

            if (distance <= agent.stoppingDistance)
			{
                enemyScript.atack();
			}

            //animator.SetTrigger("atack");
            animator.SetBool("isRunning", false);
        }
		
    }
	private void OnDrawGizmosSelected()
	{
        Gizmos.DrawWireSphere(transform.position,radius);
	}
}
