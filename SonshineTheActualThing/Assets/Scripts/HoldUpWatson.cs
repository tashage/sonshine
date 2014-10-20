using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly  //Edited by Anton Kurtz
/// Date Created: 19/8/14
/// Last Updated: 26/8/14   //15/10/14
/// Description:
/// This class serves as the action of the parent lifting up the child
/// It Does this by increasing the base offset of the childs nav mesh 
/// </summary>

public class HoldUpWatson : MonoBehaviour {

	// Use this for initialization
    public Watson m_TheChild;
    float fOriginalBaseOffset;
    float fLiftRate;

    float fMaxOffset;
    bool isPressed;

    public int holdDuration = 200;
    public int bumperMax = 75;
    int lBumper = 0;
    int rBumper = 0;

	void Start () {
        isPressed = false;

        fOriginalBaseOffset = m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset;
        fMaxOffset = fOriginalBaseOffset + 2;
        fLiftRate = 1.3f;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (m_TheChild.bTethered)
        {
            Lift();
        }
         /*if (Input.GetButtonDown("Left_Bumper")) { Debug.Log("Left"); }
         if (Input.GetButtonDown("Left_Bumper")) { Debug.Log(Input.GetButton("Left_Bumper")); }
         if (Input.GetButtonDown("Right_Bumper")) { Debug.Log("Right"); }
         if (Input.GetButtonDown("Right_Bumper")) { Debug.Log(Input.GetButton("Right_Bumper")); }
         if (Input.GetButtonDown("Right_Bumper")) { if (Input.GetButtonDown("Left_Bumper")) { Debug.Log("Both"); } }*/

	}
    bool CheckBumpers()
    {
        if (Input.GetButtonDown("Left_Bumper")) { lBumper = bumperMax; Debug.Log("Left True"); } 
        else if (lBumper > 0){ lBumper -= 1; }
        if (Input.GetButtonDown("Right_Bumper")) { rBumper = bumperMax; Debug.Log("Right True"); } 
        else if (rBumper > 0){ rBumper -= 1; }
        if((lBumper > 0)&&(rBumper > 0))
        {
            Debug.Log("Bumpers True");
            return true;
        }
        return false;
    }
    public void Lift()
    {
        // if the e key is pressed increase the base offset
		if ((Input.GetKeyDown(KeyCode.E)) || (CheckBumpers()))//((Input.GetButtonDown("Left_Bumper")) && (Input.GetButtonDown("Right_Bumper"))))
        {
            if (!isPressed)
            { rBumper = lBumper = holdDuration; }
            isPressed = true;
            

            
        }
		else if ((Input.GetKeyUp(KeyCode.E)) || (!CheckBumpers()))//((Input.GetButtonUp("Left_Bumper")) && (Input.GetButtonUp("Right_Bumper"))))
        {
            isPressed = false;
            //rBumper = lBumper = 0;
        }
      
        if (isPressed)
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < fMaxOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset += fLiftRate * Time.deltaTime;
        }
        else
        {
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset > fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset -= 1.3f * Time.deltaTime;
            if (m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset < fOriginalBaseOffset)
                m_TheChild.gameObject.GetComponent<NavMeshAgent>().baseOffset = fOriginalBaseOffset;
        }
               
            
    }

}
