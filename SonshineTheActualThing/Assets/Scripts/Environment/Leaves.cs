using UnityEngine;
using System.Collections;

public class Leaves : MonoBehaviour {

	public ParticleSystem emitter;
	public int timer, timerMax = 5000, duration = 500;
	public bool rain, wayDown;
	public int  countInc = 15;
	public float rateInc = 5.0f, gravInc = 0.01f, lifeInc = 0.5f;

	
	[HideInInspector]
	public int countOrig;
	[HideInInspector]
	public float rateOrig, gravOrig, lifeOrig;
	
	void OnTriggerEnter(Collider Player)
	{
		if(timer > (timerMax - duration))
		{
			if(wayDown)
			{
				timer = (int)(timerMax - duration);
				wayDown = false;
			}
			rain = true;
			
			
		}
	}

	void Start()
	{
		rateOrig = emitter.emissionRate;
		countOrig = emitter.maxParticles;
		gravOrig = emitter.gravityModifier;
		lifeOrig = emitter.startLifetime;
	}

	void Update()
	{
		if(((timer < timerMax)&&(!wayDown)) || (timer == 0))
		{
			timer ++;
			wayDown = false;
		}
		else if(wayDown)
		{
			timer--;
		}
		else if(timer == timerMax)
		{
			wayDown = true;
		}
		if((rain)&&(timer < timerMax)&&(!wayDown))
		{
			emitter.emissionRate += rateInc;
			emitter.maxParticles += countInc;
			emitter.gravityModifier += gravInc;
			emitter.startLifetime -= lifeInc;
		}
		
		if(timer < (timerMax - duration))
		{
			if(rain)
			{
				rain = false;

			}
		}
		if ((timer > (timerMax -duration)) && (wayDown))
		{
			emitter.emissionRate -= rateInc;
			emitter.maxParticles -= countInc;
			emitter.gravityModifier -= gravInc;
		}
		if(!rain)
		{
			emitter.emissionRate = rateOrig;
			emitter.maxParticles = countOrig;
			emitter.gravityModifier = gravOrig;
			emitter.startLifetime += lifeInc;

		}
	}
}
