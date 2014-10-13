using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    SceneFade Fade;
    public Collider player;
    GameObject[] fruit;

    public void OnTriggerEnter(Collider playerCol)
    {
        if (Fade == null)
            Fade = GetComponent<SceneFade>();

        Debug.Log("get a mullet up ya");
        fruit = GameObject.FindGameObjectsWithTag("LightFruit");
        Debug.Log(fruit.Length);
        if ((playerCol.name == "First Person Controller") && (fruit.Length == 0))
        {
            Fade.EndScene(2);
        }
    }

    void Start()
    {
        Fade = GetComponent<SceneFade>();
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
