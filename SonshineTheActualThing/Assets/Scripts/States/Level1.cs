using UnityEngine;
using System.Collections;

public class Level1 : StateTemplate
{
    SceneFade Fade;
    public Collider player;
    GameObject[] fruit;

    public void OnTriggerEnter()
    {
        fruit = GameObject.FindGameObjectsWithTag("LightFruit");
        if (fruit.Length == 0)
        {
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

    }
}
