using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class StateTemplate : MonoBehaviour
{
	public SceneManager menuManager;

    void Start()
    {
		//menuManager = GameObject.FindWithTag("Manager");
        gameObject.SetActive(false);
    }

    public StateTemplate GetState(int id)
    {
        return menuManager.allStates[id];
    }

}