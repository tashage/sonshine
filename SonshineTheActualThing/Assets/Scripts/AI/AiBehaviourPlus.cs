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
            float dist2 = Vector3.Distance(a_agent.getPosition(),a_agent.getTarget());

		    if(dist2 < m_range2)
			    return true;
		    return false;
        }
    }

    // create target : find a target based on needs etc / boredem aslong as they arent tethered.
    public class CreateTarget : AiBehaviour
    {
        public List<ChildInteractable> PossibleDistractions;

        public CreateTarget() { }

        public ChildInteractable CalculateBestOption()
        {
             // calculate what will be set
            ChildInteractable tempInteracatable = null;
            for (int i = 0; i < PossibleDistractions.Count; i++)
            {
                float tempValue = Vector3.Distance(this.transform.position, PossibleDistractions[i].gameObject.transform.position);

                // is the distraction close enough to be considered?
                if (tempValue > PossibleDistractions[i].DistractionValues.fVisibleDistance)
                {
                    // calculate weighting
                    PossibleDistractions[i].DistractionValues.fPostCheckValue = 0;

                    tempValue = tempValue * PossibleDistractions[i].DistractionValues.fDistanceWeightingFalloff
                    * PossibleDistractions[i].DistractionValues.fWeighting;

                    PossibleDistractions[i].DistractionValues.fPostCheckValue =tempValue;
                }

                // is the current checked a better value 
                // CHECK AND FIX may have to revert to a different method if this does not work
                // but this is possibly more efiicient
                int CheckVal = 0;
                for (int l = i; l > 0; l--)
                {
                    if (PossibleDistractions[i].DistractionValues.fPostCheckValue > PossibleDistractions[l].DistractionValues.fPostCheckValue)
                    {
                        CheckVal++;
                    }
                }
                if (CheckVal == i)
                {
                    tempInteracatable = PossibleDistractions[i];
                }

            }

            return tempInteracatable;
        }

        public override bool execute(Agent a_agent)
        {
            float dist2 = Vector3.Distance(a_agent.getPosition(), a_agent.getTarget());

            //if (dist2 < m_range2)//
                return true;
            return false;
        }
    }
    
    // seek target : move towards current set target 
    public class SeekTarget : AiBehaviour
    {


    }
}
