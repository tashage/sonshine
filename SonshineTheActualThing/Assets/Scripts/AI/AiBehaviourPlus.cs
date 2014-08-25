using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AiBehaviour_ns;
using Agent_ns;


/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 19/8/14
/// Description:
/// These classes will serve as the individual actions the ai may use.
/// </summary>
namespace AiBehaviourPlus_ns
{

    /// <summary>
    /// if the agent is within range of the target that was set
    /// </summary>
    public class WithinRange : AiBehaviour
    {
        private float m_range2;

        public WithinRange(float a_range) { m_range2 = a_range * a_range; }

        public override bool execute(Agent a_agent)
        {
            
            float dist2 = Vector3.Distance(a_agent.getPosition(), a_agent.getTarget());
           
            if (dist2 < m_range2 && m_range2 != 0 && dist2 !=0)
            {
                Debug.Log("executing within range as true");
                return true;
            }
            else
            {
                Debug.Log("executing within range as false");
                return false;
            }
        }
    }

    // create target : find a target based on needs etc / boredem aslong as they arent tethered.
    public class CreateTarget : AiBehaviour
    {
        public List<ChildInteractable> PossibleDistractions;

        public CreateTarget() { }

        public ChildInteractable CalculateBestOption(Vector3 a_pos)
        {
             // calculate what will be set
            ChildInteractable tempInteracatable = null;
            for (int i = 0; i < PossibleDistractions.Count; i++)
            {
                float tempValue = Vector3.Distance(a_pos, PossibleDistractions[i].gameObject.transform.position);

                // is the distraction close enough to be considered?
                if (tempValue > PossibleDistractions[i].DistractionValues.fVisibleDistance)
                {
                    // calculate weighting
                    PossibleDistractions[i].DistractionValues.fPostCheckValue = 0;

                    tempValue = tempValue * PossibleDistractions[i].DistractionValues.fDistanceWeightingFalloff
                    * PossibleDistractions[i].DistractionValues.fWeighting;
                   
                    PossibleDistractions[i].DistractionValues.fPostCheckValue =tempValue;
                }
            }
            // check the values of all other distractions
            for (int d = 0; d < PossibleDistractions.Count; d++)
            {
                if (tempInteracatable == null)
                {
                    tempInteracatable = PossibleDistractions[d];
                }
                    // if the value is higher set that as the new distraction
                else if (PossibleDistractions[d].DistractionValues.fPostCheckValue < tempInteracatable.DistractionValues.fPostCheckValue)
                {
                    tempInteracatable = PossibleDistractions[d];
                }

            }

            return tempInteracatable;
        }

        public override bool execute(Agent a_agent)
        {

           
            // calculate the target
            ChildInteractable tempInteractable = CalculateBestOption(a_agent.getPosition());
            if (tempInteractable.DistractionValues.fPostCheckValue > a_agent.fBoredem)//
            {
                a_agent.setTarget(tempInteractable.gameObject.transform.position);
                //Debug.Log(tempInteractable.gameObject.transform.position);
              //  Debug.Log("executing create target as true");
                return true;
            }
            else
            {
               // Debug.Log("executing create target as false");
                a_agent.setTarget(a_agent.getPosition());
                return false;
            }
        }
    }
    
    // seek target : move towards current set target 
    public class SeekTarget : AiBehaviour
    {
         // if the distance is greater than the pre defined threshold move towards the parent
        public override bool execute(Agent a_agent)
        {
           // Debug.Log("executing seek target");

            a_agent.setPosition(Vector3.MoveTowards(a_agent.getPosition(), a_agent.getTarget(), a_agent.fMovementSpeed * Time.deltaTime));
            return true;
        }

    }

    public class IsClose : AiBehaviour
    {

        public override bool execute(Agent a_agent)
        {
            // if the agent is within below amount of distance
            if (Vector3.Distance(a_agent.getTarget(), a_agent.getPosition()) < 1.0f)
            {
                return true;
            }
            else return false;
        }

    }
}
