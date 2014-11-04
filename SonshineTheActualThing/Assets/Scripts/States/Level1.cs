using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public SceneFade Fade;
    public Collider player;
    public GameObject[] fruit;

	bool endScene = false;

    public void OnTriggerEnter(Collider playerCol)
    {
        Debug.Log("Level 1 End Reached");
		if (fruit[0].activeInHierarchy == false && fruit[1].activeInHierarchy == false)
        {
			Debug.Log("Level 1 Complete");
			endScene = true;
        }
    }
    public void Update()
    {
		if (Input.GetKey(KeyCode.Escape) == true || (Input.GetButton("Start_Button")))
        {
			Fade.QuitScene(0);
        }
		else if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButtonUp("Start_Button")))
		{
			Fade.ResetAlpha();
		}
		if(endScene)
		{
			Fade.EndScene(2);
		}
    }
}
