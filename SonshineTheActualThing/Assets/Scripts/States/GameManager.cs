using UnityEngine;
using System.Collections;


public delegate void OnStateChangeHandler();

//a Gamemanager resides in each state and holds a list of states reachable from that state

public class GameManager : MonoBehaviour 
{

    //public string[] Scenes;
    private static GameManager Manager = null;
    public event OnStateChangeHandler OnStateChange;
    State CurrentState;
    public GameObject StateScript;
    public string StartState;
    public MonoBehaviour scriptss;
    protected GameManager() { }

    // Singleton pattern implementation
    public static GameManager Instance
    {
        get
        {
            if (GameManager.Manager == null)
            {
                GameManager.Manager = new GameManager();//If the gamemanager is not init, then init, init.
            }
            return GameManager.Manager;// return self when getter is called. duh.
        }
    }

    public void SetGameState(string NewState)
    {
        this.CurrentState.SceneName = NewState;//change state. duh.
    }

	// Use this for initialization
	void Start () 
    {
        StateScript.GetComponent(StartState);
        SetGameState(CurrentState.SceneName);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    //Constantly check for state changes. level completions / pauses etc.
        CurrentState.Update();
	}
}
