using UnityEngine;
using System.Collections;


public enum GameState { NullState, Splash, MainMenu, Level1 }//Fix this ass up with all the actual states
public delegate void OnStateChangeHandler();

public class GameManager/* : MonoBehaviour*/ {

   
    private static GameManager Manager = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState CurrentState { get; private set; } 
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

    public void SetGameState(GameState NewState)
    {
        this.CurrentState = NewState;//change state. duh.
        if (OnStateChange != null)//if can 
        {
            OnStateChange();//call state's unload func
        }
    }

	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
