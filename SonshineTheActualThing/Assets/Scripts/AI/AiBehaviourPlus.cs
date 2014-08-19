using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AiBehaviour_ns;
using Agent_ns;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 13/8/14
/// Description:
/// This class will serve as the individual action the ai may use.
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

    }
    
    // seek target : move towards current set target 
    public class SeekTarget : AiBehaviour
    {


    }
}
