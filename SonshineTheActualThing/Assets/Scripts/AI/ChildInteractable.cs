using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 19/8/14
/// Last Updated: 26/8/14
/// Description:
/// These classes will serve as the individual distraction the child
/// will interact with.
/// </summary>
public class ChildInteractable : MonoBehaviour {

	// Use this for initialization

    // This class is the individual objects in the world that can distract the child.

    //FIX why the fuck does this exist
    public class Distraction
    {
        public float    fDistanceWeightingFalloff;  // this is the multiplier applied to the distance to affect the weighting.
        public float    fWeighting;                 // The weighting which will strongly effect the desirablity
        public float    fVisibleDistance;           // the minimum distance that the object can be seen/ taken into consideration
        public float    fPostCheckValue;            // when all is calculated this is the value used

        public float    fCurrentEnjoyment;          //the current level of enjoyment 
        public float    fEntertainability;          // the starting enjoyment
        public float    fEntertainabilityFalloff;   // how quickly the enjoyment drops
        public bool     IsBoredWith;                // is the child bored with it
        public float    fBoredemCooldown;           // Total cooldown until the child will consider again
        public float    fCurrentBoredemCooldown;    // Current cooldown until the child will consider again

        public bool     bProvidesLight;
      
    }

    // the values of 'this" object
    public  Distraction DistractionValues = new Distraction();
}
