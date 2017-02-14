using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public Text scoreText;
    public GameObject ball, wall1, wall2, player1, player2;
    int player1Score, player2Score;

	void Start () 
    {
        player1Score = 0;
        player2Score = 0;
	}

    void Update()
    {
        scoreText.text = player1Score + " - " + player2Score;
    }

    public void IncrementScore(string p)
    {
        if (p == "player1")
        {
            player1Score++;
        }
        else if (p == "player2")
        {
            player2Score++;
        }

        ball.GetComponent<BallHandler>().RandomizePosition();

        wall1.GetComponent<wallInGate>().BringBackToLife();
        wall2.GetComponent<wallInGate>().BringBackToLife();
    }
}
