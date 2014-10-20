using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class StateTemplate : MonoBehaviour
{
	void Start()
    {
        gameObject.SetActive(false);
    }

}