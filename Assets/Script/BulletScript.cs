using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    //variaveis
    public float bulletSpeed = 10f;
    public float lifeTime = 5f;
    public float damage = 20f;

    public GameObject triggeringEnemy;

    public AudioSource hitAudio;

    //metodos
	void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
		{
            Destroy(gameObject);
		}
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
           
            onHit();

        }
        if (other.CompareTag("Untagged"))
        {

            onHit();
        }
        if (other.CompareTag("Player"))
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Player>().health -= damage;

            onHit();
           
        }

    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.collider.CompareTag("Untagged"))
        {

            Destroy(gameObject);
        }
    }
    void onHit()
	{
        hitAudio.Play();
        Destroy(gameObject);

	}
}
