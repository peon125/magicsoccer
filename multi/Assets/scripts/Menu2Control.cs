using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2Control : MonoBehaviour 
{
    public Sprite[] picsFire, picsFrost;
    public Image whiteBigPic, blackBigPic;
    public Image[] whiteSpellPics, blackSpellPics;
    public Text[] whiteSpellDesc, blackSpellDesc;
    public Transform whiteList, blackList;
    public Image imgPrefab;
    public float distOnList;
    Sprite[,] pics;

	void Start () 
    {
        pics = new Sprite[2, 5];
        for (int i = 0; i < pics.GetLength(1); i++)
        {
            pics[0, i] = picsFire[i];
            pics[1, i] = picsFrost[i];
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

    }
}
