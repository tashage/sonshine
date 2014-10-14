using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Jacob Connelly
/// Date Created: 14/8/14
/// Last Updated: 17/9/14
/// Description: 
/// This script will be used to tether the child to the parent
/// </summary>

public class Tether : MonoBehaviour {

	// Use this for initialization
   public Watson m_TheChild;
    float fMinDistanceToTether;
	void Start () {
        fMinDistanceToTether = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Left_Trigger"))// || Input.GetButtonDown("RightTrigger"))
		{
			Debug.Log("Tether");
		}

        // if the space key is pressed tether or un tether the child
		if (Input.GetKeyDown(KeyCode.Space) || (Input.GetButtonDown("Left_Trigger") && Input.GetButtonDown("RightTrigger")))
        {
            // if the child is NOT tethered 
            if(m_TheChild !=null)
            if (m_TheChild.bTethered == false)
            {
                if (Vector3.Distance(m_TheChild.transform.position, transform.position) < fMinDistanceToTether)
                {
                    m_TheChild.bTethered = true;
                    m_TheChild.m_light.setIntensity(0.4f);
                    m_TheChild.m_light.SetRange(75.0f);
                }
            }
            else // if the child is tethered
            {
                m_TheChild.m_light.setIntensity(0.1f);
                m_TheChild.bTethered = false;
                m_TheChild.m_light.SetRange(35.0f);
            }
                
        }
	}
}
