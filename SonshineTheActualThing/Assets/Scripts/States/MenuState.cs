using UnityEngine;
using System.Collections;

public class MenuState : StateTemplate
{
    SceneFade Fade;
	
	bool changeLv1 = false;
    bool changeLv2 = false;
    
	void Start()
    {
		Fade = GameObject.FindObjectOfType<SceneFade>();
		
    }
	
    public void Update()
    {
		if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Space)) || (Input.GetButtonUp("Jump")) || (changeLv1))
        {
			
			if (!changeLv1)
            {
                changeLv1 = true;//once button is pressed state change will come through every frame
            }
            
            Fade.EndScene(1);
        }
		if ((Input.GetKeyDown(KeyCode.Alpha2)) || (changeLv2))
        {
			
			if (!changeLv2)
            {
                changeLv2 = true;
            }
            
            Fade.EndScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuManager.SetState(GetState(menuManager.allStates.Length -1));
        }
    }
}
