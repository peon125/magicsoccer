using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySet : MonoBehaviour 
{
    public Text[] selectTexts;
    float a, b;

	void Start() 
    {
        //TODO if players are selecting

	}
	
	void Update() 
    {
        a = 0.5f;
        b = 0f;

        for (int i = 0; i < selectTexts.Length; i++)
        {
            float alpha = Mathf.Lerp(1f, 0f, b / a);
            selectTexts[i].color = new Color(selectTexts[i].color.r, selectTexts[i].color.g, selectTexts[i].color.b, alpha);

            b += Time.deltaTime;
        }
	}
}
