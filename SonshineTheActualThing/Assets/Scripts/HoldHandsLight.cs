using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Tash
/// Date Created: 18/8/14
/// Last Updated: 20/8/14
/// Description:
/// class turns light on when player and Watson collide (will be when holding hands)
/// </summary>
public class HoldHandsLight : MonoBehaviour {

    public Light kidLight;
    public Collider playerCollider;

    bool bTethered = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (bTethered)
        {
            //Debug.Log("tethered!");
            if (kidLight.intensity < 0.9f)
            {
                kidLight.intensity += 0.05f;
            }
        }
        else
        {
            if (kidLight.intensity > 0.2f)
            {
                kidLight.intensity -= 0.02f;
            }
        }
        //Debug.Log("light intensity = " + kidLight.intensity);

        //try range instead of intensity....
        //kidLight.intensity = 0.9f;
        //if (bTethered)
        //{
        //    //Debug.Log("tethered!");
        //    if (kidLight.range < 50)//(kidLight.intensity < 0.9f)
        //    {
        //        kidLight.range += 1;//kidLight.intensity += 0.05f;
        //    }
        //}
        //else
        //{
        //    if (kidLight.range > 20)//(kidLight.intensity > 0.2f)
        //    {
        //        kidLight.range -= 1;//kidLight.intensity -= 0.02f;
        //    }
        //}
	}


    //I guess tethered will be an agent bool, and this function will use that value
    //in the meantime, "tether" will just be a collision"
    void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            bTethered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            bTethered = false;
        }
    }
}
