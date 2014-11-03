using UnityEngine;
using System.Collections;
/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 17/9/14
/// Description: 
/// This script will just serve as the initialisation and values of the light fruit
/// </summary>
public class LightFruitAI : ChildInteractable
{
    public GameObject pathFireflies;
     void Start()
        {
            DistractionValues.fDistanceWeightingFalloff = 0.5f;
            DistractionValues.fWeighting = 10.0f ;
            DistractionValues.fVisibleDistance = 40.0f;
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

        public void Eat()
        {
            if (pathFireflies != null)
            {
              
                pathFireflies.SetActive(true);
              
            }
        }
       
}
