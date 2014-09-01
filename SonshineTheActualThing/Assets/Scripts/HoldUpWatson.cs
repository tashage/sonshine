using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 19/8/14
/// Last Updated: 26/8/14
/// Description:
/// This class serves as the action of the parent lifting up the child
/// It Does this by increasing the base offset of the childs nav mesh 
/// </summary>

public class HoldUpWatson : MonoBehaviour {

	// Use this for initialization
    public Watson m_TheChild;
    bool isPressed;

	void Start () {
        isPressed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
         if(m_TheChild.bTethered)
            Lift();
	}
    public void Lift()
    {
        // if the e key is pressed increase the base offset
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
            
        }
        else if ( Input.GetKeyUp(KeyCode.E))
        {
            isPressed = false;
        }
      
        if (isPressed)
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < 3)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset += 1.3f * Time.deltaTime;
        }
        else
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset > 1.1)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset -= 1.3f * Time.deltaTime;
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < 1.1)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset = 1.1f;
        }
               
            
    }

}
