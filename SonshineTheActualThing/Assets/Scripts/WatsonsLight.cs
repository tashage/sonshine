using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WatsonsLight : MonoBehaviour {

	// Use this for initialization

    bool  bLightOn;
    float fFlickerRange;
    float fCurrentStrength;
    float fCurrentLost;
    float fRateOfChange;
    float fRateOfLoss;              // must be less than 0, the lower the slower it decreases
    float fStartingStrength;

    float fWorldLightRateOfLoss;

    //graphing stuff
    public List<Light> m_TheLights;
    public Light m_WorldLight;          
    List<float> lightPoints;

    public void setIntensity(float a_intensity) { fCurrentStrength = a_intensity; fStartingStrength = a_intensity; }
    public void setRateOfLoss(float a_rateOfLoss) { fRateOfLoss = a_rateOfLoss; }


    // FIX still needs to be setup in the update or rewritten
    public void turnOn() { bLightOn = true; }
    public void turnOff() { bLightOn = false; }

	void Start () {
        fStartingStrength = 0.2f;
        fCurrentStrength = 0.1f;
        fCurrentLost = 0;

        fRateOfChange = 0.2f;
        fRateOfLoss = 0.01f;
        fFlickerRange = 0.1f;

        fWorldLightRateOfLoss = 0.2f;
        m_WorldLight.intensity = 0;
        lightPoints = new List<float>();
       

        lightPoints.Add(Random.Range(fStartingStrength - fFlickerRange, fStartingStrength + fFlickerRange));
        lightPoints.Add(Random.Range(fStartingStrength - fFlickerRange, fStartingStrength + fFlickerRange));
      
	}
	
	// Update is called once per frame
	void Update () {



        // get current strength and lerp towards next point in list
        if (fCurrentStrength < lightPoints[0])
        {
            fCurrentStrength += fRateOfChange * Time.deltaTime ;
            // create new point
            if (fCurrentStrength > lightPoints[0])
            {
                lightPoints.Remove(lightPoints[0]);
                lightPoints.Add(Random.Range(fStartingStrength - fFlickerRange, fStartingStrength + fFlickerRange));
            }
        }
        else if (fCurrentStrength > lightPoints[0])
        {
            fCurrentStrength -= fRateOfChange * Time.deltaTime;
            if (fCurrentStrength < lightPoints[0])
            {
                lightPoints.Remove(lightPoints[0]);
                lightPoints.Add(Random.Range(fStartingStrength - fFlickerRange, fStartingStrength + fFlickerRange));
            }
        }
        else
        {
            lightPoints.Remove(lightPoints[0]);
            lightPoints.Add(Random.Range(fStartingStrength - fFlickerRange, fStartingStrength + fFlickerRange));
        }


        for (int l = 0; l < m_TheLights.Count; l++)
            m_TheLights[l].intensity = fCurrentStrength;

        // Dim the world light
        if (m_WorldLight.intensity > 0)
            m_WorldLight.intensity -= fWorldLightRateOfLoss * Time.deltaTime;
       
	}

    // make the world light "explode"
    public void StartWorldLight()
    {
        m_WorldLight.intensity = 1.6f;
    }
}
