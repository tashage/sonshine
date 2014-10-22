using UnityEngine;
using System.Collections;

public class MenuState : StateTemplate
{
    public SceneFade Fade;
	public MenuManager menuManager;

	bool changeLv1 = false;
    bool changeLv2 = false;
    
	void Start()
    {
		//Fade = GameObject.FindObjectOfType<SceneFade>();
    }
	
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
		if ((Input.GetKeyDown(KeyCode.Alpha2)) || (changeLv2))
        {
			
			if (!changeLv2)
            {
                changeLv2 = true;
            }
            
            Fade.EndScene(2);
        }
		if (Input.GetKey(KeyCode.Escape) || (Input.GetButton("Start_Button")))
        {
			Fade.QuitScene();
        }
		else if (Input.GetKeyUp(KeyCode.Escape) || (Input.GetButtonUp("Start_Button")))
		{
			Fade.ResetAlpha();
		}
    }
	
}
