using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevel(SceneName);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public string SceneName;
}
