using UnityEngine;
using System.Collections;

public class QuitState : StateTemplate 
{

	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
