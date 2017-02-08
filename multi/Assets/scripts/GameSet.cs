using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour 
{
    public GameObject[] characters;
    public AudioClip dadadedadadada;
    int whiteSelectedSet, blackSelectedSet;
    string[] set0, set1, set2, set3;
    int whiteIndex, blackIndex;

	void Start() 
    {
        GetComponent<AudioSource>().Play();

        DontDestroyOnLoad(gameObject);

        whiteSelectedSet = -1;
        blackSelectedSet = -1;

        set0 = new string[4];
        set1 = new string[4];
        set2 = new string[4];
        set3 = new string[4];
        set1[0] = "verticalSet1";
        set2[0] = "verticalSet2";
        set3[0] = "verticalSet3";
        for (int i = 1; i < set1.Length; i++)
        {
            set1[i] = "skill" + i + "Set1";
            set2[i] = "skill" + i + "Set2";
            set3[i] = "skill" + i + "Set3";
        }
        for (int i = 0; i < set0.Length; i++)
        {
            set0[i] = "0";
        }
	}

    public string[] getWhiteSet()
    {
        switch (whiteSelectedSet)
        {
            case -1:
                return set0;
            case 0:
                return set1;
            case 1:
                return set2;
            case 2:
                return set3;
        }

        return new string[0];
    }

    public int getWhiteSelectedSet()
    {
        return whiteSelectedSet;
    }

    public void setWhiteSelectedSet(int i)
    {
        whiteSelectedSet = i;
    }

    public string[] getBlackSet()
    {
        switch (blackSelectedSet)
        {
            case -1:
                return set0;
            case 0:
                return set1;
            case 1:
                return set2;
            case 2:
                return set3;
        }

        return new string[0];
    }

    public int getBlackSelectedSet()
    {
        return blackSelectedSet;
    }
    
    public void setBlackSelectedSet(int i)
    {
        blackSelectedSet = i;
    }

    public GameObject[] getCharacters()
    {
        return characters;
    }

    public GameObject getWhiteCharacter()
    {
        return characters[whiteIndex];
    }

    public void setWhiteCharacter(int character)
    {
        whiteIndex = character;
    }

    public GameObject getBlackCharacter()
    {
        return characters[blackIndex];
    }

    public void setBlackCharacter(int character)
    {
        blackIndex = character;
    }
}
