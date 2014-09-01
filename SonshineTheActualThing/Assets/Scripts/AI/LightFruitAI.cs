using UnityEngine;
using System.Collections;

public class LightFruitAI : ChildInteractable
{
  
     void Start()
        {
            DistractionValues.fDistanceWeightingFalloff = 0.5f;
            DistractionValues.fWeighting = 10.0f ;
            DistractionValues.fVisibleDistance = 70.0f;
            DistractionValues.fPostCheckValue =0f ;

            DistractionValues.bProvidesLight = true;
           // DistractionValues.fCurrentEnjoyment;
           // DistractionValues.fEntertainability;
           // DistractionValues.fEntertainabilityFalloff;
           // DistractionValues.IsBoredWith;
           // DistractionValues.fBoredemCooldown;
           // DistractionValues.fCurrentBoredemCooldown;   
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
       
}
