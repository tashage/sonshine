using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    GameManager Manager;

    void Awake()
    {
        Manager = GameManager.Instance;
        Manager.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + Manager.currentState);

        Manager.SetGameState(GameState.MAIN_MENU);
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
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Manager.SetGameState(GameState.LEVEL_ONE);
        }
    }
}