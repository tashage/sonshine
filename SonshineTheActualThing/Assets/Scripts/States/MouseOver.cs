using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

    GameObject GetClicked()
    {
        //some poser shit. real ray casting is later
        Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);//work out where to raycast
        RaycastHit Object;//whatever is hit will be returned here

        //actual ray casting happens here. shit is gonna get real
        if (Physics.Raycast(MouseRay, Mathf.Infinity))
        {
            return Object.transform.gameObject;
        }
        else
        {
            return null;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

        }
	}
}
