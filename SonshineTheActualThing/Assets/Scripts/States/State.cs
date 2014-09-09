using UnityEngine;
using System.Collections;

//a state holds a name and requirements to change to that state

public class State : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	public virtual void Update () 
    {
        //check if requirements are met to change to thi state.#swagk;
	
	}
    protected void ChangeState(string _State, string _Button)
    {
        if (Input.GetKeyDown(_Button))//Or xBox Controls or whateverthafuk we doin
        {
            Application.LoadLevel(_State);
            Debug.Log("Changing state");
        }
    }
    //protected bool ChangeState(string _State, string _Button, ADD FOR XBOX);

    public string SceneName;
    public string[] Scenes;
}
