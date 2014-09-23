using UnityEngine;


public delegate void OnStateChangeHandler();

public class GameManager
{
    public Transform ManagerObject;
    private static GameManager Manager = null;
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
            this.currentState.Deactivate(false);

            this.currentState = newState;
            newState.stateActive = true;
        }
    }

    public void SetGameState(StateTemplate newState,GameObject Old)
    {  
        if (this.currentState != newState)
        {
            this.currentState.Deactivate(false, Old);

            this.currentState = newState;
            newState.stateActive = true;
        }
    }
    void Awake()
    {
        Object.DontDestroyOnLoad(ManagerObject);
    }
}
