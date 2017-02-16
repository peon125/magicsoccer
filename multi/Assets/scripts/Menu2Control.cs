using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2Control : MonoBehaviour 
{
    public Sprite[] picsFire, picsFrost;
    public string[] fireSpellDesc, frostSpellDesc;
    public Image whiteBigPic, blackBigPic;
    public Image[] whiteSpellPics, blackSpellPics;
    public Transform whiteList, blackList;
    public Image imgPrefab;
    public float distOnList;
    Sprite[,] pics;
    string[,] descriptions;

	void Start () 
    {
        pics = new Sprite[2, 5];
        descriptions = new string[2,3];
        for (int i = 0; i < pics.GetLength(1); i++)
        {
            pics[0, i] = picsFire[i];
            pics[1, i] = picsFrost[i];
        }

        for (int i = 0; i < descriptions.GetLength(1); i++)
        {
            descriptions[0, i] = fireSpellDesc[i];
            descriptions[1, i] = frostSpellDesc[i];
        }

        for (int i = 0; i < pics.GetLength(0); i++)
        {
            imgPrefab.sprite = pics[i, 3]; //i keep little avatars on the fourth position
            Instantiate(imgPrefab, new Vector3(whiteList.transform.position.x, whiteList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), whiteList);
            Instantiate(imgPrefab, new Vector3(blackList.transform.position.x, blackList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), blackList);
        }
	}

    public void setWhitePicsAndDesc(int i)
    {
        whiteBigPic.sprite = pics[i, 4];

        for (int j = 0; j < whiteSpellPics.Length; j++)
        {
            whiteSpellPics[j].sprite = pics[i, j];
            whiteSpellPics[j].transform.GetChild(0).GetComponent<Text>().text = descriptions[i, j];
        }
    }

    public void setBlackPicsAndDesc(int i)
    {
        blackBigPic.sprite = pics[i, 4];

        for (int j = 0; j < blackSpellPics.Length; j++)
        {
            blackSpellPics[j].sprite = pics[i, j];
            blackSpellPics[j].transform.GetChild(0).GetComponent<Text>().text = descriptions[i, j];
        }
    }
}
