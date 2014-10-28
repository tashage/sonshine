using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour 
{
   
    private bool sceneStarting = true;
	public float quitSpeed = 1.5f;
	public float quitMargin = 0.05f;


	public float inSpeed = 1.5f;
    public float inMargin = 0.1f;

    public float outSpeed = 1.5f;
    public float outMargin = 0.05f;


    void Awake()
    {
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

    void FadeTo(Color colour, float speed)
    {
        guiTexture.color = Color.Lerp(guiTexture.color, colour, speed * Time.deltaTime);
	}

    void StartScene()
    {
		//Debug.Log("SceneStarting");
        FadeTo(Color.clear, inSpeed);
		inSpeed += 0.001f;
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
            FadeTo(Color.black, outSpeed);
            if (guiTexture.color.a >= (1.0f - outMargin))
            {
                Application.LoadLevel(sceneNumber);
                sceneStarting = true;
            }
        }
    }

	public void QuitScene()
	{
		if (!sceneStarting)
		{
			guiTexture.enabled = true;
			FadeTo(Color.black, quitSpeed);
			if (guiTexture.color.a >= (1.0f - quitMargin))
			{
				Application.Quit();
				Debug.Log("you just quit");
			}
		}
	}
	public void QuitScene(int SceneNumber)
	{
		if (!sceneStarting)
		{
			guiTexture.enabled = true;
			FadeTo(Color.black, quitSpeed);

			if (guiTexture.color.a >= (1.0f - quitMargin))
			{
				Application.LoadLevel(SceneNumber);
				sceneStarting = true;
			}
		}
	}
	public void ResetAlpha()
	{
		while (guiTexture.color.a > 0.0f)
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, 100 * Time.deltaTime);
		}

		guiTexture.enabled = false;
	}
}
