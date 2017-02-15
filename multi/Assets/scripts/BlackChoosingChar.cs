using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChoosingChar : MonoBehaviour 
{
    public Menu2Control gameController;
    public GameObject arrowPrefab;
    public Transform listT;
    GameObject[] characters;
    GameObject arrow;
    GameSet gameSetter;
    Settings settings;
    string[] buttonsSet;
    int index;

    void Start()
    {
        settings = GameObject.Find("settings").GetComponent<Settings>();
        index = 0;
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();
        buttonsSet = gameSetter.getBlackSet();
        characters = gameSetter.getCharacters();
        arrow = Instantiate(arrowPrefab, new Vector3(listT.position.x + 30, listT.position.y, 0), new Quaternion(0, 90, 0, 0), transform) as GameObject;
        if (buttonsSet[0] == "0")
        {
            IAmABot();
        }
    }

    void Update()
    {
        if (settings.getIsPaused())
        {
            return;
        }

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
            //gameController.setBlackPicsAndDesc(index);
            Input.ResetInputAxes();
        }
    }

    void IAmABot()
    {
        index = 0;//Random.Range(0, characters.Length);
        gameSetter.setBlackCharacter(index);
        arrow.SetActive(false);
    }
}
