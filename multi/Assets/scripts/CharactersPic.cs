using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersPic : MonoBehaviour 
{
    Image img;

	void Start() 
    {
        img = gameObject.GetComponent<Image>();
	}
	
    void ChangePicture(Sprite sprite)
    {
        img.sprite = sprite;
    }
}
