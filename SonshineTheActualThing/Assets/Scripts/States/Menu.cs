using UnityEngine;
using System.Collections;

public class Menu : StateTemplate
{



    public override GameState Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            return GameState.LEVEL_ONE;
        }
        return GameState.NULL;
    }

}
