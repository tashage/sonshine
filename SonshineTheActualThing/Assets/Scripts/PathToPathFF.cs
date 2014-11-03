using UnityEngine;
using System.Collections;

public class PathToPathFF : MonoBehaviour {

	// Use this for initialization
    public GameObject From;  // when this game object is no longer active activat this
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!From.activeInHierarchy)
        {
            this.gameObject.SetActive( true);

        }
	}
}
