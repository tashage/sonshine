using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WatsonSoundManager : MonoBehaviour {

	// Use this for initialization
    // these are just sounds he makes
    public List<AudioClip> sounds;
    AudioSource audioSource;
    bool bNoisePlayed;
    bool bAlreadyTethered;
    
    Watson watson;
	void Start () {
        watson = GetComponent<Watson>();
        bNoisePlayed = true ;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!bNoisePlayed)
        {
            int rand = Random.Range(0, sounds.Count-1);
            Debug.Log(rand);
            //audioSource = new AudioSource();
            audioSource.clip = sounds[rand];
            Debug.Log("log" + audioSource.pitch);
            audioSource.Play();
            bNoisePlayed = true;
        }

        if (watson.bTethered)
        {
            bAlreadyTethered = true;
        }
        else if(bAlreadyTethered &&bNoisePlayed)
        {
            bAlreadyTethered = false;
            bNoisePlayed = false;
        }
	}
}
