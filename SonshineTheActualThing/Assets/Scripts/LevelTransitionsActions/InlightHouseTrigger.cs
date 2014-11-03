using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 3/11/2014
/// Last Updated: 3/11/2014
/// Description: 
/// This script will be used to shine a spotlight at the boat when watson is in the top of the light house,
/// this is intended to be attached to something with a collision box.
/// </summary>

public class InlightHouseTrigger : MonoBehaviour {

    bool bSpotlightOn = false;
    public Light thisSpotlight;
    public GameObject goTheBoat;
    public Boat theBoat;
	// Use this for initialization
	void Start () {
        thisSpotlight.intensity = 0;
        theBoat = goTheBoat.GetComponent<Boat>();
        thisSpotlight.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        // if watson has collided shine light at boat and make boat move to shore
        if (bSpotlightOn)
        {
            //Debug.Log("spot light on");
            thisSpotlight.intensity = 3;
            thisSpotlight.transform.LookAt(goTheBoat.transform);
            theBoat.LightHouseOn();
            thisSpotlight.gameObject.SetActive(true);
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
       if(!bSpotlightOn)
            if (other.gameObject.tag == "Child")
            {
                Debug.Log("Watson in the house");
                bSpotlightOn = true;
            }
    }
}
