using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    GameObject Fade;
	SceneFade fade = null;
    public Collider player;
    public GameObject[] fruit;

    public void OnTriggerEnter(Collider playerCol)
    {
        if (fade == null)
		{
            Fade = GameObject.FindWithTag("Fader");
			fade = Fade.GetComponent<SceneFade>();
		}

        Debug.Log("Level 1 End Reached");
        //fruit = GameObject.FindGameObjectsWithTag("LightFruit");
        //Debug.Log(fruit.Length);
		if ((playerCol.name == "First Person Controller") && (fruit[0].activeInHierarchy == false && fruit[1].activeInHierarchy == false))
        {
			Debug.Log("Level 1 Complete");
            fade.EndScene(2);
        }
    }

    void Start()
    {
		//Fade = GameObject.FindWithTag("Fader");
		fade = GameObject.FindWithTag("Fader").GetComponent<SceneFade>();
		Debug.Log(Fade);
		Debug.Log(fade);
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
    }
}
