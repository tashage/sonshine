using UnityEngine;
using System.Collections;

public class FootstepSound : MonoBehaviour {

    AudioSource thisFootstepSound;
	// Use this for initialization
	void Start () {
        thisFootstepSound = this.GetComponent<AudioSource>();
        thisFootstepSound.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
           
	        thisFootstepSound.Play();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
            thisFootstepSound.Pause();
        }
	}
}
