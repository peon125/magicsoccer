using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFading : MonoBehaviour 
{
    Text[] t;
    float a;

	void Start () 
    {
        t = new Text[2];
        t[0] = transform.GetChild(0).GetComponent<Text>();
        t[1] = transform.GetChild(1).GetComponent<Text>();
        a = 0;
	}

	void Update () 
    {
        for (int i = 0; i < t.Length; i++)
        {
            if(a < 1){
                t[i].color -= new Color(0, 0, 0, Time.deltaTime);
            }
            else if (a > 1)
            {
                t[i].color += new Color(0, 0, 0, Time.deltaTime);
            }
        }
            
        a += Time.deltaTime;
        if (a >= 2)
            a = 0;
	}
}
