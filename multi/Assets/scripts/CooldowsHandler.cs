using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CooldowsHandler : MonoBehaviour 
{
    public Text[] cooldownsTexts;
    float[] cooldowns;

    void Start()
    {
        cooldowns = new float[0];
    }

	void Update() 
    {
        try
        {
            for (int i = 0; i < cooldownsTexts.Length; i++)
            {
                string textOnCounter = "";

                if (cooldowns[i] < 0)
                {
                    textOnCounter = "0.0";
                }
                else
                {
                    string cooldownText = cooldowns[i].ToString();
                    textOnCounter = cooldownText.Substring(0, cooldownText.IndexOf(".") + 2);
                }

                cooldownsTexts[i].text = textOnCounter;

                if (cooldownsTexts[i].text != "0.0")
                {
                    cooldownsTexts[i].transform.parent.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    cooldownsTexts[i].transform.parent.GetComponent<Image>().color = Color.green;
                }
            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }
	}

    public void setCooldowns(float[] f)
    {
        cooldowns = f;
    }
}