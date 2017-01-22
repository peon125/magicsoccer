using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenatlyBox : MonoBehaviour {
    public float timeInBox;
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

            if (timer >= timeInBox)
                Debug.Log("nom");
        }
        else
        {
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider colid)
    {
        if (colid.gameObject.tag == "ball")
            isBallIn = true;
    }

    void OnTriggerExit(Collider colid)
    {
        if (colid.gameObject.tag == "ball")
            isBallIn = false;
    }
}
