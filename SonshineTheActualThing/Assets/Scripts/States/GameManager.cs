using UnityEngine;


public delegate void OnStateChangeHandler();

public class GameManager
{
    public Transform ManagerObject;
    private static GameManager Manager = null;
    public StateTemplate currentState = null;
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
        // failsafe incase some "person" pushes a NULL state
        if (newState == null)
            return;

        if (currentState != newState)
        {
            if (currentState != null)
            {
                currentState.gameObject.SetActive(false);
            }

            currentState = newState;
            currentState.gameObject.SetActive(true);
        }
    }
    void Awake()
    {
        Object.DontDestroyOnLoad(ManagerObject.gameObject);
    }
}
