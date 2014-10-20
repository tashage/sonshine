using UnityEngine;
using System.Collections;

public class ONOFF : MonoBehaviour {

	// Use this for initialization
    bool on;
	void Start () {
        on = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetButtonUp("Controller_Back"))
        {
            if (on)
            {
                this.light.intensity = 0; on = false;
            }
            else
            {
                this.light.intensity = 2.35f;
                on = true;
            }
        }
	
	}
}
