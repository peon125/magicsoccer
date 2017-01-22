using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Half : MonoBehaviour {
    bool isBallIn;
    float timer;

	void Start() 
    {
        isBallIn = false;
	}

	void Update() 
    {
        if (isBallIn)
        {
            timer += Time.deltaTime;

            if (timer == 0.5f)
                Debug.Log("nom");
        }
        else
        {
            timer = 0;
        }
	}

    void OnTriggerEnter(Collider colid)
    {
        Debug.Log(colid.gameObject.name);
        if (colid.gameObject.tag == "ball")
            isBallIn = true;
    }

    void OnTriggerExit(Collider colid)
    {
        if (colid.gameObject.tag == "ball")
            isBallIn = false;
    }
}
