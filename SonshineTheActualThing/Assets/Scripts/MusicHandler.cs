using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

    
    bool seenChild =false;
    float fDistanceForSeen = 20;
    bool bHeldHandsWithsChild = false;
    bool bAteFruit = false;
    bool bNearEnd = false;
    bool bNearEndGame = false;

    bool bFade = false;
    bool bFadeFinisehd = false;
     float fSetVolume;
    public GameObject goPlayer;

    public GameObject goChild;

    public GameObject goEndPoint;

    public GameObject goEndPointGame;

    public AudioClip acIntro;
    public AudioClip acLoop1;
    public AudioClip acLoop2;
    public AudioClip acLoop3;
    public AudioClip acLoop4;
    public AudioClip acSegue1;
    public AudioClip acSegue2;
    public AudioClip acFinale;

    int iLoopPoint;
    AudioClip acLoopPoint;
    AudioClip acNextToPlay;

    AudioSource thisAudioSource;
	// Use this for initialization
	void Start () {
        thisAudioSource = this.GetComponent<AudioSource>();
        thisAudioSource.clip = acIntro;
        acNextToPlay = acLoop1;
        thisAudioSource.Play();
        iLoopPoint = 1;
        fSetVolume = thisAudioSource.volume;
	}
	
	// Update is called once per frame
	void Update () 
    {

        CheckGameStatus();
        FadeToNext();
        CheckLoopPoint();
       
	}

    // this checks the neccesary
    void CheckGameStatus()
    {
        if(!seenChild)
            if (Vector3.Distance(goPlayer.transform.position, goChild.transform.position) < fDistanceForSeen)
            {
                seenChild = true;
                acNextToPlay = acSegue1;
                SetFade();
                iLoopPoint = 2;
            
               
            }

        if(!bHeldHandsWithsChild)
            if (goChild.GetComponent<Watson>().bTethered)
            {
                bHeldHandsWithsChild = true;
                
                acNextToPlay = acLoop2;
                iLoopPoint = 3;
            }
       
        if(!bNearEnd)
            if(Vector3.Distance(goPlayer.transform.position, goEndPoint.transform.position) < 10.0f)
            {
                bNearEnd=true;
                iLoopPoint = 4;
            }
        if (!bNearEndGame && goEndPointGame!=null)
            if (Vector3.Distance(goPlayer.transform.position, goEndPointGame.transform.position) < 50.0f)
            {

                bNearEndGame = true;
                acNextToPlay = acFinale;
                SetFade();
                iLoopPoint = 4;
                // close to finish
            }

        if(!thisAudioSource.isPlaying)
        {
            thisAudioSource.clip = acLoopPoint;
            thisAudioSource.Play();
        }

    }

    void CheckLoopPoint()
    {
        if (iLoopPoint == 1)
        {
            acLoopPoint = acLoop1;
        }
        else 
        if (iLoopPoint == 2)
        {
            acLoopPoint = acLoop2;
        }
        else
            
        if (iLoopPoint == 3)
        {
            acLoopPoint = acLoop3;
        }
        else
            
        if (iLoopPoint == 4)
        {
            acLoopPoint = acLoop4;
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
            thisAudioSource.volume -= Time.deltaTime ;
           
        }
        else 
        {
            if (thisAudioSource.volume < fSetVolume)
            {
                thisAudioSource.volume += Time.deltaTime;
               
            }
            if (thisAudioSource.volume > fSetVolume)
            {
                thisAudioSource.volume = fSetVolume;
            }
        }

        if (thisAudioSource.volume <= 0)
        {
            bFade = false;
            bFadeFinisehd = true;
            thisAudioSource.clip = acNextToPlay;
            thisAudioSource.Play();

        }
       
    }
}
