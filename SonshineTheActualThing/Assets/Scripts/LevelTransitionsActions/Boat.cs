using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

    public GameObject ShorePoint;
    public GameObject SeaPoint;
    

    bool bLightHouseOn = false;
    bool bPlayerInBoat = false;
    bool bChildInBoat = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (bPlayerInBoat && bChildInBoat)
        {
            bLightHouseOn = false;
            MoveTowardsSea();
        }
        if (bLightHouseOn)
        {
            MoveTowardsShore();
        }
        
	}

    public void MoveTowardsShore()
    {
       transform.position= Vector3.MoveTowards(this.transform.position, ShorePoint.transform.position, Time.deltaTime*10);
        Debug.Log("moving to shore");

    }
    public void MoveTowardsSea()
    {
        // no longer moves out to see, just fade out
        transform.position = Vector3.MoveTowards(this.transform.position, SeaPoint.transform.position, Time.deltaTime * 10);
        Debug.Log("moving to sea");
    }
    public void LightHouseOn()
    {
        bLightHouseOn = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!bLightHouseOn)
        {
            if (other.gameObject.tag == "Child")
            {
                Debug.Log("Watson in the boat");
                bChildInBoat = true;
            }
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Player In Boat");
                bPlayerInBoat = true;
            }
        }
    }
}
