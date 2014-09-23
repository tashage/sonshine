using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    GameManager Manager;
    public  GameObject Menu, Level1, Level2, Current;//States
    StateTemplate currentStateScript;

    void Awake()
    {
        Manager = GameManager.Instance;
       
        Manager.SetGameState(Menu.GetComponent<Menu>() as StateTemplate);
    }

    void Update()
    {
       // switch currentStateScript//switch to work out current stateOBJ then turn on off :D
      //  {

       // }
    }

    void LateUpdate()//check for state changes here
    {

        //currentStateScript.Active(

        StateTemplate nextState = currentStateScript.Update();

        if( nextState != Manager.currentState)
        {

            Manager.SetGameState(nextState, );
        }
    }
}