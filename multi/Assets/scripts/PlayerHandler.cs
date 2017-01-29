using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour 
{
    public float startingPositionX, startingPositionZ;
    public CooldowsHandler cooldownHandler;
    Text[] cooldownTexts;
    string[] buttonsSet;
    GameSet gameSetter;
	
	void Start () 
    {
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();


        if (gameObject.name == "player1")
        {
            buttonsSet = gameSetter.getWhiteSet();
            GameObject character = Instantiate(gameSetter.getWhiteCharacter(), new Vector3(startingPositionX, 5, startingPositionZ), new Quaternion(0, 0, 0, 0), transform);
        }
        else if (gameObject.name == "player2")
        {
            buttonsSet = gameSetter.getBlackSet();
            GameObject character = Instantiate(gameSetter.getBlackCharacter(), new Vector3(startingPositionX, 5, startingPositionZ), new Quaternion(0, 90, 0, 0), transform);   
        }
        
        cooldownTexts = cooldownHandler.cooldownsTexts;
    }

    public Text[] getCooldownTexts()
    {
        return cooldownTexts; // niepotrzebna funkcja
    }

    public string[] getButtons()
    {
        return buttonsSet;
    }
}
