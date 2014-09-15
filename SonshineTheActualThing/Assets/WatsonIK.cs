using UnityEngine;
using System.Collections;

public class WatsonIK : MonoBehaviour {

    public Animator animator;

    public bool ikActive = false; //is the inverse kinematics currently active
    public Transform rightHandObj = null;

	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (animator)
        {
            //if the ik is active, set the position and rotation directly to the goal
            if (ikActive)
            {
                //weight = 1.0f; for the right hand means position and rotation will be at the IK goal (the place where the hand has to grab
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

                //set the position and teh rotation of the right hand where the external object is
                if (rightHandObj != null)
                {
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
            }
            else //if ik is not active
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            }
        }
	}
}
