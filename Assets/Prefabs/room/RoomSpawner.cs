using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
	/*1 -- precisa de porta abaixo
       2-- precisar de porta no top
    3 -- precisa de porta a esquerda
    4 precisa de pota a direita

     
     */
	private RoomTemplates template;


	private int rand;
	private bool spawned = false;
	private void Start()
	{

		template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("spawn",1f);


	}
	private void spawn()
	{
		if(spawned == false)
		{
			if (openingDirection == 1)
			{
				rand = Random.Range(0, template.bottomRooms.Length);
				Instantiate(template.bottomRooms[rand], transform.position, template.bottomRooms[rand].transform.rotation);
			}
			else if (openingDirection == 2)
			{
				rand = Random.Range(0, template.topRooms.Length);
				Instantiate(template.topRooms[rand], transform.position, template.topRooms[rand].transform.rotation);
			}
			else if (openingDirection == 3)
			{
				rand = Random.Range(0, template.leftRooms.Length);
				Instantiate(template.leftRooms[rand], transform.position, template.leftRooms[rand].transform.rotation);
			}
			else if (openingDirection == 4)
			{
				rand = Random.Range(0, template.rightRooms.Length);
				Instantiate(template.rightRooms[rand], transform.position, template.rightRooms[rand].transform.rotation);
			}


			spawned = true;
		}
		
	}
	private void OnTriggerEnter(Collider other)
	{
		//if(other.CompareTag("RoomSpawnPoint") && other.GetComponent<RoomSpawner>().spawnned == true)
		if (other.CompareTag("RoomSpawnPoint"))
		{
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
			{
				Instantiate(template.closeRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			spawned = true; 
			
		}
	}
}
