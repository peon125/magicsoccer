using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlCharacter : MonoBehaviour
{
    public GameObject[] firesPrefabs;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    CooldowsHandler cooldownsHandler;
    Text[] cooldownTexts;
    float characterDefaultXPosistion;
    string[] buttons;

    void Start() 
    {
        PlayerHandler ph = transform.parent.GetComponent<PlayerHandler>();
        buttons =  ph.getButtons();
        cooldownTexts = ph.getCooldownTexts();
        characterDefaultXPosistion = transform.position.x;
        cooldowns = new float[3];
        cooldownsHandler = ph.cooldownHandler;
    }

    void Update() 
    {
        Move();

        Shoot();
    }

    void Move()
    {
        transform.position += new Vector3(0f, 0f, (float)Math.Round(Input.GetAxis(buttons[0]) * speed));
        transform.position = new Vector3(characterDefaultXPosistion, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        for (int j = 1; j < buttons.Length; j++)
        {
            int i = j - 1;
            if (Input.GetButtonDown(buttons[j]) && cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation);
                ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
                shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);
                shotHandler.setwhatShotAmI(i);

                cooldowns[i] = delays[i];
                break;
            }
        }

        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }

        cooldownsHandler.setCooldowns(cooldowns);
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