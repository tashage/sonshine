using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{

    public  GameObject FirstState;//States

    public StateTemplate currentState = null;
    public StateTemplate[] allStates;

	public StateTemplate GetState(int id)
	{
		return allStates[id];
	}

    public void SetState(StateTemplate newState)
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
    
    void Start()
    {
        SetState(FirstState.GetComponent<MenuState>() as StateTemplate);
    }
}