using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{

	void OnTriggerEnter()
	{
		this.SendMessageUpwards("TeleTrigger");
	}
	void OnTriggerExit()
	{
		this.SendMessageUpwards("TeleExit");
	}
}
