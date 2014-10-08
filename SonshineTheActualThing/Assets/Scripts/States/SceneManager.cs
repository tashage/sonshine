using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public  GameObject FirstState;//States
    
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        GameManager.Instance.SetGameState(FirstState.GetComponent<MenuState>() as StateTemplate);
    }
}