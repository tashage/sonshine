﻿using UnityEngine;

public enum GameState
{
    NULL = 0,
    MAIN_MENU = 1,
    LEVEL_ONE = MAIN_MENU << 1,
    PAUSE_MENU = LEVEL_ONE << 1,
    QUIT_GAME = PAUSE_MENU << 1
}

public delegate void OnStateChangeHandler();

public class GameManager :MonoBehaviour
{
    public Transform ManagerObject;
    private static GameManager Manager = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState currentState { get; private set; }
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

    public void SetGameState(GameState newState)
    {
        Debug.Log("     Current ->   " + currentState);

        Debug.Log("     New ->   " + newState);

        if (this.currentState != newState)
        {
            this.currentState = newState;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
        
            Application.LoadLevel((int)Manager.currentState);
        }
    }
    void Awake()
    {
        Object.DontDestroyOnLoad(ManagerObject);
    }
}
