using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteChoosingChar : MonoBehaviour 
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
        buttonsSet = gameSetter.getWhiteSet();
        characters = gameController.getCharacters();
        listT = transform.GetChild(0);
        arrow = Instantiate(arrowPrefab, new Vector3(listT.position.x - 30, listT.position.y, 0), new Quaternion(0, 0, 0, 0), transform) as GameObject;
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

            gameSetter.setWhiteCharacter(index);
            Input.ResetInputAxes();
        }

        if(Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("scena1");
	}
}
