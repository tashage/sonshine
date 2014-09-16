using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    GameManager Manager;

    void Awake()
    {
        Manager = GameManager.Instance;
        Manager.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + Manager.gameState);

        Manager.SetGameState(GameState.MAIN_MENU);
    }

	void Start () 
    {
        Debug.Log("Current game state when Starts: " + Manager.gameState);
	}

    public void HandleOnStateChange() 
    {
        Debug.Log("Handling state change to: " + Manager.gameState);
        
        /*switch (Manager.gameState)
        {
                case GameState.MAIN_MENU:
                Application.LoadLevel(0);
                break;
                case GameState.LEVEL_ONE:
                Application.LoadLevel(1);
                break;
                case GameState.PAUSE_MENU:

                break;
                case GameState.QUIT_GAME:

                break;
        }*/
	}
}
