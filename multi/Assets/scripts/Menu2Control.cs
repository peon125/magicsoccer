using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2Control : MonoBehaviour 
{
    //public GameObject[] characters;
    public Sprite[] smallPics, bigPics;
    public Transform whiteList, blackList;
    public Image imgPrefab;
    public float distOnList;

	void Start () 
    {
        for (int i = 0; i < smallPics.Length; i++)
        {
            imgPrefab.sprite = smallPics[i];
            Instantiate(imgPrefab, new Vector3(whiteList.transform.position.x, whiteList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), whiteList);
            Instantiate(imgPrefab, new Vector3(blackList.transform.position.x, blackList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), blackList);
        }
	}

    //public GameObject[] getCharacters()
    //{
    //    return characters;
    //}
}
