using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class StateTemplate : MonoBehaviour
{

    public SceneManager menuManager;
    void Start()
    {
        menuManager = GetComponent<SceneManager>();
        gameObject.SetActive(false);
    }

    public StateTemplate GetState(int id)
    {
        return menuManager.allStates[id];
    }

}