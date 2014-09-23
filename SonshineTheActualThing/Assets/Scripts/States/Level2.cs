using UnityEngine;
using System.Collections;

public class Level2 : StateTemplate
{
    //StateTemplate temp;

    public override void Start()
    {
        base.Start();
    }

    public override StateTemplate Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            return GetState("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            return GetState("MainMenu");
        }
        return this;
    }
}
