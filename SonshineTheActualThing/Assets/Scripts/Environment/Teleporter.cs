using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
	public Transform otherDest;
	void OnTriggerEnter()
	{
		SendMessageUpwards("TeleTrigger", otherDest.position);
	}
	void OnTriggerExit()
	{
		SendMessageUpwards("TeleExit");
	}
}
