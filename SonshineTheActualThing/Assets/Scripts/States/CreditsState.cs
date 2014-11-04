using UnityEngine;
using System.Collections;

public class CreditsState : StateTemplate 
{
	public MenuManager Manager;
	void Start()
	{
		this.gameObject.SetActive(false);
	}
	void Update () 
	{
		if (Input.GetKey(KeyCode.Escape) || (Input.GetButton("B_Button")))
		{
			Manager.SetState(0);
		}
	}
}
