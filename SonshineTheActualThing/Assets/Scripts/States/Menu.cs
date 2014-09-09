using UnityEngine;
using System.Collections;

public class Menu : State {

    public string Level1;

    /*Menu(string _onSpace)//Add a state to change to with the space button
    {
        Level1 = _onSpace;
    }*/

	void Start () 
    {
	   
	}
	
	public void Update () 
    {
	    //test here for change state
        ChangeState(Level1, "Space");
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
	}
}
