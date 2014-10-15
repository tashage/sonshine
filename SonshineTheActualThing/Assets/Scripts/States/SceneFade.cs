using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour 
{
   
    private bool sceneStarting = true;
	public float quitSpeed = 1.5f;
	public float quitMargin = 0.05f;


	public float inSpeed = 1.5f;
    public float inMargin = 0.05f;

    public float outSpeed = 1.5f;
    public float outMargin = 0.05f;

    public SceneManager menuManager;

    void Awake()
    {
        menuManager = GetComponent<SceneManager>();

        //DontDestroyOnLoad(transform.gameObject);
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color.a.Equals(1.0f);
        sceneStarting = true;
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
    }

    void FadeToClear()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, inSpeed * Time.deltaTime);
    }

    void FadeToDark()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, outSpeed * Time.deltaTime);
    }
	void QuitToDark()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, quitSpeed * Time.deltaTime);
	}

    void StartScene()
    {
        FadeToClear();

        if (guiTexture.color.a <= (0f + inMargin))
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;
            sceneStarting = false;
        }
    }
    
    public void EndScene(int sceneNumber)
    {
        if (!sceneStarting)
        {
            guiTexture.enabled = true;
            FadeToDark();
            if (guiTexture.color.a >= outMargin)
            {
                Application.LoadLevel(sceneNumber);
                sceneStarting = true;
            }
        }
    }
    public void EndScene(StateTemplate newState)
    {
        if (!sceneStarting)
        {
            guiTexture.enabled = true;
            FadeToDark();
            if (guiTexture.color.a >= outMargin)
            {
                menuManager.SetState(newState);
                sceneStarting = true;
            }
        }
    }
	public void QuitScene()
	{
		if (!sceneStarting)
		{
			guiTexture.enabled = true;
			QuitToDark();
			if (guiTexture.color.a >= quitMargin)
			{
				Application.Quit();
			}
		}
	}
}
