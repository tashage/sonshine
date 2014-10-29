using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour
{

	public float inSpeed = 1.5f, inMargin = 0.1f;

	public float outSpeed = 1.5f, outMargin = 0.05f;
	public Collider locOther, player;
	public GUITexture tex;
	public bool teleporting = false;

	public int coolDown = 0, coolMax = 400, pauseLength = 100, teleHeight = 1;

	void FadeTo(Color colour, float speed)
	{
		tex.color = Color.Lerp(guiTexture.color, colour, speed * Time.deltaTime);
	}
	void SetAlpha(bool transparent)
	{
		if(transparent)
		{
			Debug.Log("3");
			// while (guiTexture.color.a > 0.0f)
			{
				tex.color = Color.clear;
			}

			tex.enabled = false;
		}
		else
		{
			Debug.Log("4");
			//while (guiTexture.color.a < 1.0f)
			{
				tex.color = Color.black;
			}			
		}
	}

	void OnTriggerEnter()
	{
		if(coolDown == 0)//if its safe (DR ABC)
		{
			teleporting = true;//safe guard on
		}
	}
	void OnTriggerExit()
	{
			teleporting = false;
			coolDown = coolMax;
	}

	void Awake()
	{
		//tex = GetComponentInChildren<GUITexture>();
		tex.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		tex.enabled = false;
	}

	void Update()
	{
		if(coolDown > 0)//its too damn hot!
		{
			coolDown --;//cool down the cooldown
		}
		if(teleporting)
		{
			coolDown = coolMax + pauseLength;//another safeguard
			tex.enabled = true;

			FadeTo(Color.black, outSpeed);//fade out
			//empty line here, helps un-clutter things
			Debug.Log(tex.color.a);
			if (tex.color.a > (1.0f - outMargin))//if its dark time
			{
				Debug.Log("2");
				SetAlpha(false);//make it black as hell aiight
				player.transform.position = new Vector3(locOther.transform.position.x, locOther.transform.position.y + teleHeight, locOther.transform.position.z);//move player
			}

			if(coolDown <= (coolMax - pauseLength))
			{
				FadeTo(Color.clear, inSpeed);// pretty much make it clear
				if(tex.color.a < (inMargin))//finish him
				{
					SetAlpha(true);//clear the fader once and for all
				}
			}
		}
	}
}
