using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlCharacter : MonoBehaviour
{
    public GameObject[] firesPrefabs;
    public Text[] cooldownTexts;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    float characterDefaultXPosistion;
    string[] firesKeys;
    Text[] thisPlayersCooldownTexts;
    string ver, hor;

    void Start() 
    {
        characterDefaultXPosistion = transform.position.x;

        firesKeys = new string[firesPrefabs.Length];
        cooldowns = new float[firesKeys.Length];
        thisPlayersCooldownTexts = new Text[3];

        if (gameObject.name == "player1")
        {
            ver = "VerticalP1";
            hor = "HorizontalP1";

            for (int i = 0; i < thisPlayersCooldownTexts.Length; i++)
            {
                thisPlayersCooldownTexts[i] = cooldownTexts[i];
            }

            for (int i = 0; i < firesKeys.Length; i++)
            {
                firesKeys[i] = "Fire" + (i + 1) + "P1";
            }
        }

        if (gameObject.name == "player2")
        {
            ver = "VerticalP2";
            hor = "HorizontalP2";

            for (int i = 0; i < thisPlayersCooldownTexts.Length; i++)
            {
                thisPlayersCooldownTexts[i] = cooldownTexts[i + 3];
            }

            for (int i = 0; i < firesKeys.Length; i++)
            {
                firesKeys[i] = "Fire" + (i + 1) + "P2";
            }
        }
    }

    void Update() 
    {
        Move();

        Shoot();
    }

    void Move()
    {
        transform.position += new Vector3(0f, 0f, (float)Math.Round(Input.GetAxis(ver) * speed));
        transform.position = new Vector3(characterDefaultXPosistion, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        for (int i = 0; i < firesKeys.Length; i++)
        {
            if (Input.GetButtonDown(firesKeys[i]) && cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation);
                ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
                shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);
                shotHandler.setwhatShotAmI(i);

                cooldowns[i] = delays[i];
                break;
            }
        }

        for (int i = 0; i < firesKeys.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
            string textOnCounter = "";

            if (cooldowns[i] < 0)
            {
                textOnCounter = "0.0";
            }
            else
            {
                string cooldownText = cooldowns[i].ToString();
                textOnCounter = cooldownText.Substring(0, cooldownText.IndexOf(".") + 2);
            }

            thisPlayersCooldownTexts[i].text = textOnCounter;
        }
    }

    public void ResetCooldowns()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] = 0f;
        }
    }
}
