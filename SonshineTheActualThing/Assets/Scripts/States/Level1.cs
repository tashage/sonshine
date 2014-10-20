using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public SceneFade Fade;
    public Collider player;
    public GameObject[] fruit;

    public void OnTriggerEnter(Collider playerCol)
    {
        Debug.Log("Level 1 End Reached");
		if ((playerCol.name == "First Person Controller") && (fruit[0].activeInHierarchy == false && fruit[1].activeInHierarchy == false))
        {
			Debug.Log("Level 1 Complete");
            Fade.EndScene(2);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            //GameManager.Instance.SetGameState(GetState(0));
            Application.LoadLevel(0);
        }
        //debug use only
        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            //GameManager.Instance.SetGameState(GetState(1));
            Application.LoadLevel(2);
        }
        OnTriggerEnter(player);
    }
}
