using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class StateTemplate : MonoBehaviour {

    public string name;
    public bool stateActive;
    public StateTemplate[] linkedStates;


    public virtual void Start()
    {
        Deactivate(false);
    }

    public abstract StateTemplate Update();

    public bool Deactivate(bool OnOff)
    {
        stateActive = OnOff;

        return stateActive;
    }

    public bool Deactivate(bool OnOff, GameObject StateObj)
    {
        stateActive = OnOff;

        StateObj.SetActive(stateActive);
        return stateActive;
       
    }

    public StateTemplate GetState(string Name)
    {
        for (int i = 0; i < linkedStates.Length; i++)
        {
            if (linkedStates[i].name == Name)
            {
                return linkedStates[i];
            }
        }
        
        return this;
    }

}
