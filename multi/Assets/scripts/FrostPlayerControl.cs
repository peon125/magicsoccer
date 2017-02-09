using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FrostPlayerControl : MonoBehaviour
{
    public GameObject[] firesPrefabs;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    Transform bulletsTransform;
    GameObject ball;
    CooldowsHandler cooldownsHandler;
    Text[] cooldownTexts;
    float characterDefaultXPosistion;
    string[] buttons;
    bool isABot;

    void Start() 
    {
        isABot = false;
        PlayerHandler ph = transform.parent.GetComponent<PlayerHandler>();
        buttons =  ph.getButtons();
        cooldownTexts = ph.getCooldownTexts();
        characterDefaultXPosistion = transform.position.x;
        cooldowns = new float[3];
        cooldownsHandler = ph.cooldownHandler;
        bulletsTransform = GameObject.Find("bullets").transform;

        if (buttons[0] == "0")
        {
            isABot = true;
            ball = GameObject.FindGameObjectWithTag("ball");
        }
    }

    void Update() 
    {
        if (isABot)
            IAmABot();
        else
        {
            Move();

            Shoot();
        }

        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }

        cooldownsHandler.setCooldowns(cooldowns);
    }

    void Move()
    {
        transform.position += new Vector3(0f, 0f, (float)Math.Round(Input.GetAxis(buttons[0]) * speed));
        transform.position = new Vector3(characterDefaultXPosistion, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        if(Input.GetButtonDown(buttons[1]))
        {
            Debug.Log("a");
            GameObject shot = Instantiate(firesPrefabs[0], firesPrefabs[0].transform.position + transform.position, firesPrefabs[0].transform.rotation, bulletsTransform) as GameObject;
            shot.transform.GetChild(0).GetComponent<Renderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
        }

        if(Input.GetButtonDown(buttons[2]))
        {
            float position = 0;
            if (transform.position.x > 0)
            {
                position = transform.position.x - 40;
            }
            else
            {
                position = transform.position.x + 40;
            }
            Vector3 pos = new Vector3(position, firesPrefabs[1].transform.position.y, transform.position.z);
            GameObject wall = Instantiate(firesPrefabs[1], pos, firesPrefabs[1].transform.rotation, bulletsTransform) as GameObject;
            wall.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
            //ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
            //shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);
            //shotHandler.setwhatShotAmI(1);
        }

        if(Input.GetButtonDown(buttons[3]))
        {
            GameObject shot = Instantiate(firesPrefabs[2], firesPrefabs[2].transform.position + transform.position, firesPrefabs[2].transform.rotation, bulletsTransform) as GameObject;
            shot.transform.GetChild(0).GetComponent<Renderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
        }
    }

    void IAmABot()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            if (cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation, bulletsTransform);
                ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
                shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);
                shotHandler.setwhatShotAmI(i);

                cooldowns[i] = delays[i];
                break;
            }
        }

        if (ball.transform.position.z > transform.position.z)
        {
            transform.position += new Vector3(0, 0, speed);
        }
        else
        {
            transform.position -= new Vector3(0, 0, speed);
        }
    }

    public void ResetCooldowns()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] = 0f;
        }
    }

    public float[] getCooldowns()
    {
        return cooldowns;
    }
}