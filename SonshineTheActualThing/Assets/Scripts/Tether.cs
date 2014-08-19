using UnityEngine;
using System.Collections;


/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 13/8/14
/// Description: 
/// This script will be used to tether the child to the 
/// player
/// </summary>
public class Tether : MonoBehaviour {

    // this is what "this" tethers to 
    public GameObject   goParentTether;
  

  
    public bool         bTethered;        // whether or not this object the child is tethered
    private float       fMovementSpeed;
    private float       fTetherThreshold;

	// Use this for initialization
	void Start () {
        fMovementSpeed = 1.0f;
        fTetherThreshold = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // if they are tethered stay near them 
        if (bTethered)
        {
            // find the distance to the parent
            float distance = Vector3.Distance(transform.position, goParentTether.transform.position);

            // if the distance is greater than the pre defined threshold move towards the parent
            if (distance > fTetherThreshold)
                transform.position = Vector3.MoveTowards(transform.position, goParentTether.transform.position, fMovementSpeed * Time.deltaTime);
        }

	}
}
