using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootstepSound : MonoBehaviour {

    AudioSource thisFootstepSound;
    bool isWalking;
    public float fTimeBetweenSteps;
    float fTimeSinceLastStep;

    public List<AudioClip> FootStepsSounds;
	// Use this for initialization
	void Start () {
        thisFootstepSound = this.GetComponent<AudioSource>();
        thisFootstepSound.Stop();

        thisFootstepSound.clip = FootStepsSounds[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            isWalking = true;
	       
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
           
            isWalking = false;
        }

        // 
        if (isWalking)
        {
            Debug.Log("TRUE WALKING:: " + isWalking);
            if (!thisFootstepSound.isPlaying || fTimeSinceLastStep > fTimeBetweenSteps  )
            {
                Debug.Log("SOUND DONE PLAYING:: " + thisFootstepSound.isPlaying);

                thisFootstepSound.clip = FootStepsSounds[Random.Range(0, FootStepsSounds.Count -1)];
                thisFootstepSound.Stop();
                thisFootstepSound.Play();
                fTimeSinceLastStep = 0;
                
            }
            //thisFootstepSound.Play();
        }
        else
        {
            thisFootstepSound.Pause();
        }

        fTimeSinceLastStep += Time.deltaTime;
	}
}
