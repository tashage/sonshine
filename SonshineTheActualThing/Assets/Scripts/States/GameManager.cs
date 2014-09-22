using UnityEngine;


//When creating a new state you must... 
//      +add the scene to the build settings.
//      +Make a new statechangemanager.
//      +add it to the 
        


public delegate void OnStateChangeHandler();

public class GameManager :MonoBehaviour
{
    public Transform ManagerObject;
    private static GameManager Manager = null;
    public event OnStateChangeHandler OnStateChange;
    public StateTemplate currentState { get; set; }
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

    public void SetGameState(StateTemplate newState)
    {  
        if (this.currentState != newState)
        {
            currentState.stateActive = false;
            this.currentState = newState;
            newState.stateActive = true;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
        
        }
    }
    void Awake()
    {
        Object.DontDestroyOnLoad(ManagerObject);
    }
}
