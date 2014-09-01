using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AiBehaviour_ns;
using AiBehaviourPlus_ns;
using Agent_ns;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 13/8/14
/// Last Updated: 26/8/14
/// Description: 
/// This script will be used as the overall actions of the child to the 
/// player
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

    public WatsonsLight m_light;
    // behaviours 
    SeekTarget seek = new SeekTarget();
    CreateTarget random = new CreateTarget();
    WithinRange  within = new WithinRange(20.0f) ;// = new WithinRange(10.0f); // the range passed through is the overall visible range, like a first step in checking

    public List<ChildInteractable> Distractions;

    // remember sequence will 
    Sequence seq = new Sequence();
    Selector root = new Selector();
    // Use this for initialization
    void Start()
    {
        fMovementSpeed = 5.0f;
        m_agent.fMovementSpeed = fMovementSpeed;
        fTetherThreshold = 1.0f;
        m_agent.fBoredem = -1.0f;
        m_agent.fVisionRange = 45.0f;
        fStepThreshold = 0.015f;
        
        m_agent.fRotationSpeed = 1.4f;

        // initialise the behaviours
        m_behaviour = new AiBehaviour();
        seek = new SeekTarget();
        random = new CreateTarget();
        within = new WithinRange(m_agent.fVisionRange);

        random.PossibleDistractions = Distractions;

        // build the behaviour tree
        seq.addChild(within);
        seq.addChild(random);

        root.addChild(seq);
        root.addChild(seek);

        m_behaviour = root;

        // check
        //print(random.PossibleDistractions[0].DistractionValues.fWeighting);
       // print(random.PossibleDistractions[1].DistractionValues.fWeighting);
        m_agent.setBehaviour(m_behaviour);

       
        m_agent.setPosition(transform.position);
        m_agent.setTarget(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        // if they are tethered stay near them 
        if (bTethered)
        {
            // find the distance to the parent
            float distance = Vector3.Distance(transform.position, goParentTether.transform.position);
            m_light.turnOn();
            // if the distance is greater than the pre defined threshold move towards the parent
           // if (distance > fTetherThreshold)
             //   transform.position = Vector3.MoveTowards(transform.position, goParentTether.transform.position, fMovementSpeed * Time.deltaTime);

            // reset the agent position so there is no jitter
            m_agent.setPosition(transform.position);
            m_agent.setTarget(goParentTether.transform.position);

            // use nav mesh to move infront of the player
            GetComponent<NavMeshAgent>().destination = goParentTether.transform.position + goParentTether.transform.forward*2;
            // and rotate towards target
            Vector3 targetDir = goParentTether.transform.position - transform.position;
            float step = m_agent.fRotationSpeed * Time.deltaTime;
           // Debug.Log(targetDir.x);
            if (targetDir.x > fStepThreshold)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
            else if (targetDir.x < -fStepThreshold)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
        else
        {
            // idle / execute the behaviour tree
            m_agent.update();
            m_light.turnOff();
            //print(m_agent.getPosition());

            //calculate Position
            Vector3 tempPos = new Vector3() ;
            tempPos.x = m_agent.getPosition().x;
          
            GetComponent<NavMeshAgent>().destination = m_agent.getPosition();

            //transform.position = tempPos;

            // and rotate towards target
            Vector3 targetDir = m_agent.getTarget() - transform.position;
           
            float step = m_agent.fRotationSpeed * Time.deltaTime;

            if (step > fStepThreshold)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
               
                Quaternion tempquat = Quaternion.LookRotation(newDir);
                tempquat.x = transform.rotation.x;
                transform.rotation = tempquat;
            }
            
        }
    }// update 
    void OnTriggerEnter(Collider other)
    {
//        Debug.Log("coliding");
        if (other.gameObject.tag == "Child")
            Destroy(gameObject);
    }
}
