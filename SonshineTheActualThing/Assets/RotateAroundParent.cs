using UnityEngine;
using System.Collections;

public class RotateAroundParent : MonoBehaviour {

    private float fRotateAroundSpeed;
    GameObject parent;
	// Use this for initialization
	void Start () {
        // cos 7 8 9
        fRotateAroundSpeed = 8;
        parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float step = fRotateAroundSpeed * Time.deltaTime;
        this.gameObject.transform.RotateAround(parent.transform.position,Vector3.up, step);
	}
}
