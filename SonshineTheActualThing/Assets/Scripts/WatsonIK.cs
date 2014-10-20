using UnityEngine;
using System.Collections;

public class WatsonIK : MonoBehaviour {

    public Animator animator;

    public bool ikActive = false; //is the inverse kinematics currently active
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;

	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {
        //animator = GetComponent<Animator>();
    }

    //IK Animation Function
	void OnAnimatorIK () {
        if (animator)
        {
            //if the ik is active, set the position and rotation directly to the goal
            if (ikActive)
            {
                //weight = 1.0f; for the right hand means position and rotation will be at the IK goal (the place where the hand has to grab
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

                //set the position and teh rotation of the right hand where the external object is
                if (Input.GetMouseButton(1) && rightHandObj != null)
                {
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, rightHandObj.rotation);
                }
                if (Input.GetMouseButton(0) && leftHandObj != null)
                {
                    animator.SetIKPosition(AvatarIKGoal.RightHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, leftHandObj.rotation);
                }
            }
            else //if ik is not active
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
	}
}
