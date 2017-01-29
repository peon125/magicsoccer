using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownCounter : MonoBehaviour 
{
    Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }
	void Update() 
    {
        if (text.text != "0.0")
        {
            transform.parent.GetComponent<Image>().color = Color.red;
        }
        else
        {
            transform.parent.GetComponent<Image>().color = Color.green;
        }
	}
}
