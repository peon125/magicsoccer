using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersPic : MonoBehaviour 
{
    public Sprite[] picsFireChar;
    public string[] descFireChar;
    public Sprite[] picsFrostChar;
    public string[] descFrostChar;
    Sprite[,] pics;
    string[,] desc;

    void Start()
    {
        pics = new Sprite[2,4];
        desc = new string[2,3];
    }
}