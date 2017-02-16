using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteChoosingChar : MonoBehaviour 
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
        buttonsSet = gameSetter.getWhiteSet();
        characters = gameSetter.getCharacters();
        arrow = Instantiate(arrowPrefab, new Vector3(listT.position.x - 30, listT.position.y, 0), new Quaternion(0, 0, 0, 0), transform) as GameObject;
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

        if (Input.GetButtonDown(buttonsSet[0]))
        {
            if (Input.GetAxis(buttonsSet[0]) < 0)
            {
                if (index < characters.Length - 1)
                {
                    index++;
                    arrow.transform.position -= new Vector3(0, 50, 0);
                }

            }
            else if (Input.GetAxis(buttonsSet[0]) > 0)
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

        gameController.setWhitePicsAndDesc(index);

        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("scena1");
    }

    void IAmABot()
    {
        index = Random.Range(0, characters.Length);
        gameSetter.setWhiteCharacter(index);
        arrow.SetActive(false);
    }
}
