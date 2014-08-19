using UnityEngine;
using System.Collections;

public class ChildInteractable : MonoBehaviour {

	// Use this for initialization

    // This class is the individual objects in the world that can distract the child.
    public class Distraction
    {
        public float    fDistanceWeightingFalloff;  // this is the multiplier applied to the distance to affect the weighting.
        public float    fWeighting;                 // The weighting which will strongly effect the desirablity
        public float    fVisibleDistance;           // the minimum distance that the object can be seen/ taken into consideration

        public float    fCurrentEnjoyment;          //the current level of enjoyment 
        public float    fEntertainability;          // the starting enjoyment
        public float    fEntertainabilityFalloff;   // how quickly the enjoyment drops
        public bool     IsBoredWith;                // is the child bored with it
        public float    fBoredemCooldown;           // Total cooldown until the child will consider again
        public float    fCurrentBoredemCooldown;    // Current cooldown until the child will consider again

    }    
}

public class LightFruit : ChildInteractable
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
