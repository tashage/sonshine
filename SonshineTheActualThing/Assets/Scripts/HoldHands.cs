using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 18/8/14
/// Last Updated: 19/8/14
/// Description:
/// class turns light on when player and Watson collide (will be when holding hands)
/// </summary>
public class HoldHands : MonoBehaviour {

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
	}

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
