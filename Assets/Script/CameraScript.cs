using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Variaveis
    public Transform player;
    public float smooth = 0.3f;
	public float hight = 5;
	public float camDist = 7f;
	

    private Vector3 velocity = Vector3.zero;



    //Metodos
    private void Update()
	{
		Vector3 position = new Vector3();
		position.x = player.position.x;
		position.z = player.position.z - camDist;
		position.y = player.position.y + hight;

		transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smooth);

	}

}
