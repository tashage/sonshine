using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    GameManager Manager;
    public  GameObject Menu, Level1, Level2;//States
    StateTemplate currentStateScript;

    void Awake()
    {
        Manager = GameManager.Instance;
        Manager.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + Manager.currentState);
        currentStateScript = Menu.GetComponent<StateTemplate>();
        Manager.SetGameState(currentStateScript);
        currentStateScript.stateActive = true;
    }

	void Start () 
    {
        Debug.Log("Current game state when Starts: " + Manager.currentState);
	}

    public void HandleOnStateChange() 
    {
        Debug.Log("Handling state change to: " + Manager.currentState);
	}

    void LateUpdate()//check for state changes here
    {
        switch (currentStateScript.Update())//if current state's body is ready
        {
            case GameState.NULL:    
                break;
            case GameState.LEVEL_ONE:
                Manager.SetGameState(Level1.GetComponent<StateTemplate>());
                break;
        }
    }
}