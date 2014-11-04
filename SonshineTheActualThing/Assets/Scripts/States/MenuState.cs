using UnityEngine;
using System.Collections;

public class MenuState : StateTemplate
{
    public SceneFade Fade;
	public MenuManager menuManager;

	bool changeLv1 = false;
	bool changeLv2 = false;
	
    public void Update()
    {
		if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Space)) || (Input.GetButtonUp("A_Button")) || (changeLv1))
        {
			
			if (!changeLv1)
            {
                changeLv1 = true;//once button is pressed state change will come through every frame
            }
            
            Fade.EndScene(1);
        }
		if (Input.GetKey(KeyCode.Escape) || (Input.GetButton("B_Button")))
        {
			Fade.QuitScene();
        }
		else if (Input.GetKeyUp(KeyCode.Escape) || (Input.GetButtonUp("B_Button")))
		{
			Fade.ResetAlpha();
		}
		else if (Input.GetButton("Y_Button"))
		{
			menuManager.SetState(2);
		}
		else if (Input.GetButton("Back_Button"))
		{
			menuManager.SetState(1);
			
		}
    }
	
}
