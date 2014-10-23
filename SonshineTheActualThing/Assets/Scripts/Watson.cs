using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AiBehaviour_ns;
using AiBehaviourPlus_ns;
using Agent_ns;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 17/9/14
/// Description: 
/// This script will be used as the controlling and interaction of the child
/// </summary>

public class Watson : MonoBehaviour
{

    // this is what "this" tethers to 
    public GameObject goParentTether;

    private Agent m_agent = new Agent();
    private AiBehaviour m_behaviour;


    public bool bTethered;          // whether or not this object the child is tethered
    private float fMovementSpeed;     //double check this
    private float fTetherThreshold;
    private float fStepThreshold;    // this is to do with rotation towards the target, the step must be higher than this to calculate
    private float fRotationalTwitchThreshold;

    public WatsonsLight m_light;

    // behaviours 
    SeekTarget seek = new SeekTarget();
    CreateTarget target = new CreateTarget();
    WithinRange  within = new WithinRange(20.0f) ;// = new WithinRange(10.0f); // the range passed through is the overall visible range, like a first step in checking
    IsBondStrong bond = new IsBondStrong(5);
    IsClose isclose = new IsClose();
    //Avoid avoid = new Avoid(goParentTether.transform.position);

    public List<ChildInteractable> Distractions;

    // remember sequence will 
    Sequence seq = new Sequence();
    Selector ifCloseToPoint = new Selector();
    Selector root = new Selector();


    // Use this for initialization
    void Start()
    {
        fMovementSpeed = GetComponent<NavMeshAgent>().speed;
        m_agent.fMovementSpeed = fMovementSpeed;
        fTetherThreshold = 1.0f;
        m_agent.fBoredem = -1.0f;
        m_agent.fVisionRange = 45.0f;
        fStepThreshold = 0.2f;
        
        m_agent.fRotationSpeed = 1.6f;
        m_agent.fPlayerBond = 0;
        fRotationalTwitchThreshold = 0.5f;

        // initialise the behaviours
        m_behaviour = new AiBehaviour();
        seek = new SeekTarget();
        target = new CreateTarget();
        within = new WithinRange(m_agent.fVisionRange);

        target.PossibleDistractions = Distractions;

        // build the behaviour tree
        ifCloseToPoint.addChild(seek);
        ifCloseToPoint.addChild(isclose);

        seq.addChild(within);
        seq.addChild(target);

        root.addChild(seq);
        root.addChild(ifCloseToPoint);  


        
        m_behaviour = root;

        m_agent.setBehaviour(m_behaviour);
       
        m_agent.setPosition(transform.position);
        m_agent.setTarget(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        m_agent.update();
        // if they are tethered stay near them 
        if (bTethered)
        {
            // find the distance to the parent
            float distance = Vector3.Distance(transform.position, goParentTether.transform.position);
            m_light.turnOn();
            

            // this is so the child slowly moves infront of the player , not rushing to wards it, shits creepy
            if (distance < 1)
                GetComponent<NavMeshAgent>().speed = distance;
            else
                GetComponent<NavMeshAgent>().speed = fMovementSpeed;
          
            // reset the agent position so there is no jitter
            m_agent.setPosition(transform.position);
            m_agent.setTarget(goParentTether.transform.position);

            // use nav mesh to move infront of the player
                    // yes this is a quick and terrible fix but i need it to work
                    // this is so if the player is moving forward watson is infront
            if(Input.GetKey(KeyCode.W))
                GetComponent<NavMeshAgent>().destination = goParentTether.transform.position + goParentTether.transform.forward*4f ;
            else
                GetComponent<NavMeshAgent>().destination = goParentTether.transform.position + goParentTether.transform.forward * 2;

            // and rotate towards target/player
            Vector3 targetDir = goParentTether.transform.position - transform.position;
           
            float step = m_agent.fRotationSpeed * Time.deltaTime;
           
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            // we only need to rotate on the y axis
            Quaternion q = new Quaternion(0, Quaternion.LookRotation(newDir).y, 0, Quaternion.LookRotation(newDir).w);
            transform.rotation = q;
           
            // strengthen the player bond;
            if (m_agent.fPlayerBond < m_agent.fPlayerBondMax)
            {
                m_agent.fPlayerBond += Time.deltaTime * m_agent.fPlayerBondIncreaseRate;
                m_agent.fPlayerBondMinLine += Time.deltaTime * m_agent.fPlayerBondIncreaseRate * 0.25f; // a quarter so an actual strong bond develops
            }
            else
            {

            }

        }
        else
        {

            m_light.turnOff();
            
            //calculate Position
            Vector3 tempPos = new Vector3() ;
            tempPos.x = m_agent.getPosition().x;
          
            GetComponent<NavMeshAgent>().destination = m_agent.getPosition();
            
            // and rotate towards target
            Vector3 targetDir = m_agent.getTarget() - transform.position;
           
            float step = m_agent.fRotationSpeed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            // we only need to rotate on the y axis
            Quaternion q = new Quaternion(0, Quaternion.LookRotation(newDir).y, 0, Quaternion.LookRotation(newDir).w);
            transform.rotation = q;
            
        }


        /// this area handles animations 
        /// or you can do it within the actual behaviours
        if(m_agent.GetBehaviour().m_BehaviourType == AiBehaviour.BehaviourType.ISCLOSE) //example
        {
            return;//bitchs on empty function
        }

      }// update 
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("coliding");
        if (other.gameObject.tag == "LightFruit")
        {
            other.gameObject.SetActive( false);
           // Destroy(other.gameObject);
            m_light.StartWorldLight();
        }
    }
}
