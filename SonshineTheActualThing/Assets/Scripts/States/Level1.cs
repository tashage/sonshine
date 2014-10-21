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
		if (fruit[0].activeInHierarchy == false && fruit[1].activeInHierarchy == false)
        {
			Debug.Log("Level 1 Complete");
            Fade.EndScene(2);
        }
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            //Application.LoadLevel(0);
			Fade.QuitScene(0);
        }
		else if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButton("Start_Button")))
		{
			Fade.ResetAlpha();
		}
        //debug use only
        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            Application.LoadLevel(2);
        }
    }
}
