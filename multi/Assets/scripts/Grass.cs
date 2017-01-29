using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {
    Color[] c;
    float time;

	void Start () 
    {
        c = new Color[60];

        setColorsInATable(c.Length, out c);
	}

	void Update () 
    {
        time += Time.deltaTime;

        if (time >= 0.2f)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            time = 0;
        }
	}

    void setColorsInATable(int a, out Color[] c)
    {
        //This is my brilliant algorithm based on a "chosing color" palette in GIMP.
        c = new Color[a];
        c[0] = Color.white;

        float f = 360 / a;
        f /= 60;
        float limit = 1f;
        int i = 1;

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(limit, f * o, 0f);
            i++;
        }

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(limit - f * o, limit, 0f);
            i++;
        }

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(0f, limit, f * o);
            i++;
        }

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(0f, limit - f * o, limit);
            i++;
        }

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(f * o, 0f, limit);
            i++;
        }

        for (int o = 0; i < c.Length; o++)
        {
            if (f * o > limit)
            {
                break;
            }
            c[i] = new Color(limit, 0f, limit - f * o);
            i++;
        }
    }
}
