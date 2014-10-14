using UnityEngine;
using System.Collections;

public class Level2 : StateTemplate
{
    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            GameManager.Instance.SetGameState(GetState(0));
        } 
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            GameManager.Instance.SetGameState(GetState(1));
        }
    }
}
