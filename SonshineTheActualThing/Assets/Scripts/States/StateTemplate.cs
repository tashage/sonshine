using UnityEngine;
using System.Collections;


public enum GameState
{
    NULL = 0,
    MAIN_MENU = 1,
    LEVEL_ONE = MAIN_MENU << 1,
    PAUSE_MENU = LEVEL_ONE << 1,
    QUIT_GAME = PAUSE_MENU << 1
}

public class StateTemplate : MonoBehaviour {

    public GameState thisState;
    public bool stateActive;
    public GameState[] linkedStates;

    public virtual GameState Update () //if !active return
    {
        if (!stateActive)
        {
            return GameState.NULL;
        }

        //any more stuff goes here

        return GameState.NULL;
	}

    public void onTransition()
    {

    }
}
