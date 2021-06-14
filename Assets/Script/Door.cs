using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public DoorEvent doorEvent;

	

	private Quaternion startRotation;
	private Vector3 RotateTo;
    // Start is called before the first frame update
    void Start()
    {
		doorEvent.OnDoorEnterTrigger += DoorEvent_OnDoorEnterTrigger;
		doorEvent.OnDoorExitTrigger += DoorEvent_OnDoorExitTrigger;


		startRotation = gameObject.transform.rotation;
		RotateTo = new Vector3(0, -90, 0);
    }


	private void DoorEvent_OnDoorEnterTrigger(Collider obj)
	{
		gameObject.transform.rotation = Quaternion.Euler(RotateTo);
	}

	private void DoorEvent_OnDoorExitTrigger(Collider obj)
	{
		gameObject.transform.rotation = startRotation;
	}

	
	// Update is called once per frame
	void Update()
    {
        
    }
}
