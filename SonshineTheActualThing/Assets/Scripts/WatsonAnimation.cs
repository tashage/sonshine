using UnityEngine;
using System.Collections;

public class WatsonAnimation : MonoBehaviour {

    public Animator WatsonAnimator; //reference the animator
    private bool LMBDown, RMBDown; 

	// Use this for initialization
	void Start () {
        LMBDown = false;
        RMBDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        //mouse buttons: left = 0, right = 1, middle = 2
        //check if left button is pressed
        if (Input.GetMouseButton(0))
        {
            LMBDown = true;
        }
        else
        {
            LMBDown = false;
        }
        //check if right button is pressed
        if (Input.GetMouseButton(1))
        {
            RMBDown = true;
        }
        else
        {
            RMBDown = false;
        }

        //update the animator variables
        //WatsonAnimator.SetBool("LMBDown", LMBDown);
        //WatsonAnimator.SetBool("RMBDown", RMBDown);
	}
}
