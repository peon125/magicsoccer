using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackChoosingSet : MonoBehaviour 
{
    public GameObject arrow;
    public Transform canvasTransform;
    public GameObject[] setsGOs;
    GameSet gameSetter;
    GameObject selectionArrow, pressToSelect;
    Settings settings;
    string[] sets;
    int selectedSet;

    void Start() 
    {
        pressToSelect = new GameObject();
        settings = GameObject.Find("settings").GetComponent<Settings>();
        sets = new string[3];
        sets[0] = "skill2Set1";
        sets[1] = "skill2Set2";
        sets[2] = "skill2Set3";
        selectedSet = -1;
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();
    }

    void Update ()
    {    
        if (settings.getIsPaused())
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            for (int i = 0; i < sets.Length; i++)
            {
                if (Input.GetButtonDown(sets[i]) && GetComponent<WhiteChoosingSet>().getSelectedSet() != i)
                {
                    Transform t = setsGOs[i].transform;
                    foreach (Transform child in t)
                    {
                        if (child.tag == "pressToSelect")
                            pressToSelect = child.gameObject;
                    }

                    if (selectionArrow != null)
                    {
                        Destroy(selectionArrow);
                    }

                    if (selectedSet == i)
                    {
                        selectedSet = -1;
                        pressToSelect.SetActive(true);
                        gameSetter.setBlackSelectedSet(-1);
                    }
                    else
                    {
                        selectedSet = i;
                        pressToSelect.SetActive(false);
                        selectionArrow = Instantiate(arrow, new Vector3(t.position.x + 30, t.position.y), new Quaternion(0, 90, 0, 0), t) as GameObject;
                        gameSetter.setBlackSelectedSet(i);
                    }

                }
            }
        }
    }

    public int getSelectedSet()
    {
        return selectedSet;
    }
}