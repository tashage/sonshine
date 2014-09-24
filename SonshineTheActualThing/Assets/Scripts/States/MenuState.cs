using UnityEngine;
using System.Collections;

public class MenuState : StateTemplate
{

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.SetGameState(GetState(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.SetGameState(GetState(1));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //GameManager.Instance.currentState = GetState("MainMenu");
        }
    }
}
