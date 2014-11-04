using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{

    public  GameObject FirstState;//States

    public GameObject currentState = null;
    public GameObject[] allStates;

	public GameObject GetState(int id)
	{
		return allStates[id];
	}

    public void SetState(int newState)
    {
        // failsafe incase some "person" pushes a NULL state
        //if (newState == null)
        //    return;

		if (currentState != allStates[newState])
        {
            if (currentState != null)
            {
                currentState.SetActive(false);
            }
			else
			{
				
			}
				currentState = allStates[newState];
				currentState.SetActive(true);
            
            
        }
    }
    
    void Start()
    {
        // turn the mouse off
        Screen.showCursor = false;
		this.gameObject.SetActive(true);

        SetState(0);
    }
}