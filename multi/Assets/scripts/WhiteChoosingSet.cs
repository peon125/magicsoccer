using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class WhiteChoosingSet : MonoBehaviour 
{
    public GameObject arrow;
    public Transform canvasTransform;
    public GameObject[] setsGOs;
    GameSet gameSetter;
    GameObject selectionArrow;
    string[] sets;
    int selectedSet;

    void Start() 
    {
        sets = new string[3];
        sets[0] = "skill1Set1";
        sets[1] = "skill1Set2";
        sets[2] = "skill1Set3";
        selectedSet = -1;
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();
    }

    void Update ()
    {    
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < sets.Length; i++)
            {
                if (Input.GetButtonDown(sets[i]) && GetComponent<BlackChoosingSet>().getSelectedSet() != i)
                {
                    Transform t = setsGOs[i].transform;
                    GameObject pressToSelect = new GameObject();
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
                        return;
                    }

                    selectedSet = i;
                    pressToSelect.SetActive(false);
                    selectionArrow = Instantiate(arrow, new Vector3(t.position.x - 30, t.position.y), new Quaternion(0, 0, 0, 0), t) as GameObject;
                    gameSetter.setWhiteSelectedSet(i);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && GetComponent<BlackChoosingSet>().getSelectedSet() != -1 && selectedSet != -1)
        {
            SceneManager.LoadScene("menu2");
        }
    }

    public int getSelectedSet()
    {
        return selectedSet;
    }
}