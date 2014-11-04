using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour
{

	public float fadeInMargin, speed, fadeOutMargin;
	public Collider tele1, tele2;
	public GameObject player, child;
	Vector3 locOther, childDest;
	CharacterController playerController;
	public GameObject fader;
	Color destColour;
	public bool teleporting = false;

	public int coolDown, coolMax, pauseLength, teleHeight;

	void FadeTo(Color colour, float speed)
	{
		fader.guiTexture.color = Color.Lerp(fader.guiTexture.color, colour, speed * Time.deltaTime);
	}
	void SetAlpha(bool transparent)
	{
		if(transparent)
		{
			fader.guiTexture.color = Color.clear;
			fader.guiTexture.enabled = false;
			
		}
		else
		{
				fader.guiTexture.color = Color.black;		
		}
	}

void TeleTrigger(Vector3 childdest)
	{
		if(coolDown == 0)//if its safe (DR ABC)
		{
			teleporting = true;//safe guard on
			coolDown = coolMax + pauseLength;//another safeguard
			
			childDest = childdest;//where watson will go

			fader.guiTexture.enabled.Equals(true);//turn it on to be used
			playerController.enabled.Equals(false);
			
			if ((Vector3.Distance(player.transform.position, tele1.transform.position)) > (Vector3.Distance(player.transform.position, tele2.transform.position)))//which is closer
			{
				locOther = tele1.transform.position;//you are at 2. 1 is where you will go
			}
			else
			{
				locOther = tele2.transform.position;//you are at 1. 2 is where you will go
			}
			

		}
	}
	void TeleExit()
	{
			coolDown = coolMax;
	}

	void Awake()
	{
		fader.guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		playerController = player.GetComponent<CharacterController>();
		destColour = Color.black;
	}

	void Update()
	{
		if(teleporting)
		{
			FadeTo(destColour, speed);//fade out to whatever dest =

			if(destColour == Color.black)
			{
				if (fader.guiTexture.color.a > (1.0f - fadeOutMargin))
				{
					SetAlpha(false);//make it totally black because it pretty much alreaady is.
					destColour = Color.clear; //we know its black as. now we set its dest to clear for phase 2
					player.transform.position = locOther;//move player
					if(child.GetComponent<Watson>().bTethered)
					{
						child.SetActive(false);//turn that sucka down
						child.transform.position = childDest;//move child
						child.SetActive(true);//boot up time motha fucka

					}
				}
			}
			else
			{
				if (fader.guiTexture.color.a < (fadeInMargin))
				{
					teleporting = false;
					SetAlpha(true);
					destColour = Color.black;//prepare system for a reset
					fader.guiTexture.enabled.Equals(false);//turn off on to be used

				}
			}
		}
		if (coolDown > 0)//its too damn hot!
		{
			coolDown--;//cool down the cooldown
		}
	}
		/*bool pause = false;
		if(teleporting)
		{
			if(destColour == Color.black)
			{
				fader.guiTexture.enabled.Equals(true);//turn it on to be used

				FadeTo(destColour, outSpeed);//fade out
				//empty line here, helps un-clutter things
				if ((fader.guiTexture.color.a > (1.0f - outMargin)) && (player.transform.position != locOther))//if its dark time and the player hasn't already teleported.
				{
					SetAlpha(false);//make it black as hell aiight
					player.transform.position = locOther;//move player
					Debug.Log("Player Moved to " + locOther + "   player pos   " + player.transform.position);
					destColour = Color.clear;
				}
			}

			if(coolDown <= (coolMax - pauseLength) && (destColour == Color.clear))
			{
				pause = true;
				teleInSpeed += 0.01f;
				FadeTo(destColour, teleInSpeed);// pretty much make it clear
				if ((fader.guiTexture.color.a < (teleInMargin))&&(playerController.enabled == false))//finish him -if not already
				{
					pause = false;
					Debug.Log("About to re enable Character controller and fade to clear");
					SetAlpha(true);//clear the fader once and for all
					playerController.enabled.Equals(true);
					teleporting = false;
					destColour = Color.black;
					fader.guiTexture.enabled.Equals(false);//we're done.

				}
			}
		}
		
		if((coolDown > 0) && !pause)//its too damn hot!
		{
			coolDown --;//cool down the cooldown
		}
		if(coolDown == 0)
		{
			teleporting = false;
		}
	}*/
}
