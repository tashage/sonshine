using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Author: Jacob Connelly
/// Date Created: 14/8/14
/// Last Updated: 17/9/14
/// Description: 
/// This script will be used to tether the child to the parent
/// </summary>
public class PlayerSoundManager : MonoBehaviour {

    // Use this for initialization
    // these are just sounds he makes
    public List<AudioClip> sounds;
    AudioSource audioSource;
    public float fTimeBetweenFootsteps;
    private float fTimeSinceLastFootstep;
    public AudioClip continuousFootsteps;
    
    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = continuousFootsteps;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
           
        }
        else// if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Pause();
            
        }
    }
}
