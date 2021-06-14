using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    public string ActivateTag = "Player";


    
    
    public event System.Action<Collider> OnDoorEnterTrigger;
    public event System.Action<Collider> OnDoorExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag.Equals(ActivateTag))
		{
            OnDoorEnterTrigger(other);
        }
       
    }
	private void OnTriggerExit(Collider other)
	{
        if (other.tag.Equals(ActivateTag))
        {
            OnDoorExitTrigger(other);
        }
      
    }
}
