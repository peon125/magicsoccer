using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChoosingChar : MonoBehaviour 
{
    public Menu2Control gameController;
    public GameObject arrowPrefab;
    GameSet gameSetter;
    GameObject[] characters;
    string[] buttonsSet;
    int index;
    GameObject arrow;
    Transform listT;

    void Start()
    {
        index = 0;
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();
        buttonsSet = gameSetter.getBlackSet();
        characters = gameController.getCharacters();
        listT = transform.GetChild(0);
        arrow = Instantiate(arrowPrefab, new Vector3(listT.position.x + 30, listT.position.y, 0), new Quaternion(0, 90, 0, 0), transform) as GameObject;
    }

    void Update()
    {
        if(Input.GetButtonDown(buttonsSet[0]))
        {
            if (Input.GetAxis(buttonsSet[0]) < 0)
            {
                if (index < characters.Length - 1)
                {
                    index++;
                    arrow.transform.position -= new Vector3(0, 50, 0);
                }

            } else if(Input.GetAxis(buttonsSet[0]) > 0)
            {
                if (index > 0)
                {
                    index--;
                    arrow.transform.position += new Vector3(0, 50, 0);
                }
            }

            gameSetter.setBlackCharacter(index);
            Input.ResetInputAxes();
        }
    }
}
