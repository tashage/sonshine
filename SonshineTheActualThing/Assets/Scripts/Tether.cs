using UnityEngine;
using System.Collections;

public class Tether : MonoBehaviour {

	// Use this for initialization
   public Watson m_TheChild;
    float fMinDistanceToTether;
	void Start () {
        fMinDistanceToTether = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(m_TheChild !=null)
            if (m_TheChild.bTethered == false)
            {
                if (Vector3.Distance(m_TheChild.transform.position, transform.position) < fMinDistanceToTether)
                {
                    m_TheChild.bTethered = true;

                }
            }
            else
            {
                m_TheChild.bTethered = false;
            }
                
        }
	}
}
