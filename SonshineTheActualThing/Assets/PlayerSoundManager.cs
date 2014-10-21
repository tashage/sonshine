using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
          /*  if(fTimeSinceLastFootstep > fTimeBetweenFootsteps && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                                                                   Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)))
            {
                fTimeSinceLastFootstep = 0;
                int rand = Random.Range(0, sounds.Count - 1);
                Debug.Log(rand);
               
                audioSource.clip = sounds[rand];
              
                Debug.Log("log" + audioSource.pitch);
                audioSource.Play();
            }
            fTimeSinceLastFootstep += Time.deltaTime;
            */

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
            Debug.Log("footsteps go");
        }
        else// if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Pause();
            Debug.Log("footsteps stop");
        }
    }
}
