using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour 
{
    string ver, fire1, fire2, fire3;

	void Start () 
    {
        SetKeys("VerticalP1", "Fire1P1", "Fire2P1", "Fire3P1");
	}
	
	void Update () 
    {
		
	}

    void SetKeys(string ver, string fire1, string fire2, string fire3)
    {
        this.ver = ver;
        this.fire1 = fire1;
        this.fire2 = fire2;
        this.fire3 = fire3;
    }
}
