using UnityEngine;
using System.Collections;

public class Level1 : StateTemplate
{

    public override void Start()
    {
        base.Start();
    }

    public override StateTemplate Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            return GetState("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            return GetState("Level2");
        }
        return this;
    }
}
