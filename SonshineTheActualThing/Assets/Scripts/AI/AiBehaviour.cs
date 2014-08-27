using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Agent_ns;


/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 26/8/14
/// Description: This class contains and uses the building blocks of
/// the ai behaviour and behaviour trees.
/// Fleshed out proper behaviours are past the basics
/// </summary>

namespace AiBehaviour_ns
{
    /// <summary>
    /// These behaviours are the basic nodes etc. 
    /// Fleshed out proper behaviours are underneath
    /// </summary>
    public class AiBehaviour 
    {

        public AiBehaviour() { }

        virtual public bool execute(Agent a_agent) { return false; }

    };
    public class Composite : AiBehaviour
    {
        protected List<AiBehaviour> m_children;
        public Composite() { m_children = new List<AiBehaviour>(); }

        

        public void addChild(AiBehaviour a_behavior) { m_children.Add(a_behavior); }

    };
    public class Selector : Composite
    {
        public Selector() { }

        override public bool execute(Agent a_agent)
        {
            for (int c = 0; c < m_children.Count; c++)
            {
                if (m_children[c].execute(a_agent) == true)
                    return true;
            }
            return false;
        }

    };

    public class Sequence : Composite
    {
       public Sequence() { }

       override public bool execute(Agent a_agent)
        {
            for (int c = 0; c < m_children.Count; c++)
            {
                if (m_children[c].execute(a_agent) == true)
                    return false;
            }
            return true;
        }

    };
}



