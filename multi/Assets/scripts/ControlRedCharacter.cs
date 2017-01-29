using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ControlRedCharacter : MonoBehaviour {

    public GameObject[] firesPrefabs;
    public Text[] cooldownTexts;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    float characterDefaultXPosistion;
    string[] firesKeys;
    Text[] thisPlayersCooldownTexts;

    string ver, fire1, fire2, fire3;

    void Start() 
    {
        characterDefaultXPosistion = transform.position.x;

        firesKeys = new string[firesPrefabs.Length];
        cooldowns = new float[firesKeys.Length];
        thisPlayersCooldownTexts = new Text[3];

        SetControl("VerticalP1", "Skill1P1", "Skill2P1", "Skill3P1"); //TODO napisac tu pobieranie tych klawiszy z gamesettera
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

    void SetControl(string ver, string fire1, string fire2, string fire3)
    {
        this.ver = ver;
        this.fire1 = fire1;
        this.fire2 = fire2;
        this.fire3 = fire3;
    }
}
