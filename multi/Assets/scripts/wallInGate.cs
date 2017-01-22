using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallInGate : MonoBehaviour 
{
    int durability;
    Transform wallTransform;

	void Start () 
    {
        durability = 3;
        wallTransform = transform;
	}

    void OnCollisionEnter(Collision colid)
    {
        if (colid.gameObject.tag == "ball")
        {
            durability--;

            switch (durability)
            {
                case 2:
                    transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f);
                    break;
                case 1:
                    transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 0:
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    public void BringBackToLife()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
        gameObject.SetActive(true);
        durability = 3;
    }
}
