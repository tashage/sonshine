using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

    
    bool seenChild =false;
    float fDistanceForSeen = 40;
    bool bHeldHandsWithsChild = false;
    bool AteFruit = false;

    bool bFade = false;
    bool bFadeFinisehd = false;

    public GameObject goPlayer;

    public GameObject goChild;

    public AudioClip acIntro;
    public AudioClip acLoop1;
    public AudioClip acLoop2;
    public AudioClip acLoop3;
    public AudioClip acLoop4;
    public AudioClip acSegue1;
    public AudioClip acSegue2;
    public AudioClip acFinale;

    AudioClip acNextToPlay;

    AudioSource thisAudioSource;
	// Use this for initialization
	void Start () {
        thisAudioSource = this.GetComponent<AudioSource>();
        thisAudioSource.clip = acIntro;
        acNextToPlay = acLoop1;
        thisAudioSource.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {

        CheckGameStatus();

        // when the change over happens
       /* if (thisAudioSource.isPlaying == false)
        {
            if (seenChild)
            {
                if (bHeldHandsWithsChild)
                {
                    acNextToPlay = acSegue1;
                    Debug.Log("next to play" + acNextToPlay.name);
                }
                else
                {
                    acNextToPlay = acLoop1;
                    Debug.Log("next to play" + acNextToPlay.name);
                }
            }
            thisAudioSource.clip = acNextToPlay;
            thisAudioSource.Play();
            Debug.Log("Playing" + thisAudioSource.clip.name);
        }*/
	}

    // this checks the neccesary
    void CheckGameStatus()
    {
        if(!seenChild)
        if (Vector3.Distance(goPlayer.transform.position, goChild.transform.position) < fDistanceForSeen)
        {
            seenChild = true;
            acNextToPlay = acSegue1;
            
            thisAudioSource.Play();
            Debug.Log("seen child");
        }

        if(!bHeldHandsWithsChild)
        if (goChild.GetComponent<Watson>().bTethered)
        {
            bHeldHandsWithsChild = true;
            Debug.Log("HeldHands");
        }

    }
    void SetFade()
    {
        bFade = true;
        bFadeFinisehd = false;
    }
    void FadeToNext()
    {
        if (bFade)
        {
            thisAudioSource.volume -= Time.deltaTime / 10;
        }
        if (thisAudioSource.volume <= 0)
        {
            bFade = false;
            bFadeFinisehd = true;
        }
    }
}
