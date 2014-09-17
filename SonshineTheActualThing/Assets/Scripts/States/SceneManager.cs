﻿using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    GameManager Manager;

    void Awake()
    {
        Manager = GameManager.Instance;
        Manager.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + Manager.currentState);

        Manager.SetGameState(GameState.NULL);
        Debug.Log("State has been set");
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
        if (Manager.currentState == GameState.NULL)
        {
            Manager.SetGameState(GameState.MAIN_MENU);
        }

        else if (Input.GetButtonDown("space"))
        {
            Manager.SetGameState(GameState.LEVEL_ONE);
        }
    }
}