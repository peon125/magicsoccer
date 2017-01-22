using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour 
{
    public GameController gameController;

    void OnTriggerEnter(Collider colid)
    {
        

        if (colid.gameObject.tag == "ball")
        {
            
            string whichPlayer = "";

            if (transform.position.x < 0)
            {
                whichPlayer = "player2";
            }
            else if (transform.position.x > 0)
            {
                whichPlayer = "player1";
            }

            gameController.IncrementScore(whichPlayer);
        }
    }

}
