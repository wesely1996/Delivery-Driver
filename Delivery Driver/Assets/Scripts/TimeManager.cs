using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float timeRemaining = 180f;
    [SerializeReference] TextMeshProUGUI timeText;
    [SerializeReference] GameObject player;
    [SerializeReference] TextMeshProUGUI finalScore;
    [SerializeReference] TextMeshProUGUI pizzaText;
    [SerializeReference] GameObject gameOverPanel;

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.RoundToInt(timeRemaining);
        }
        else
        {
            player.GetComponent<Movement>().gameHasEnded = true;
            finalScore.text = "GAME OVER\nSCORE: " + player.GetComponent<Delivery>().pizzaCounter;
            gameOverPanel.SetActive(true);
        }
    }

    public void playAgain()
    {
        player.GetComponent<Movement>().gameHasEnded = false;
        timeRemaining = 180f;
        timeText.text = "Time: " + Mathf.RoundToInt(timeRemaining);
        player.transform.position = new Vector3(6.3f, -0.4f, 0);
        player.GetComponent<Movement>().ResetSpeed();
        player.GetComponent<Delivery>().ResetGame();
        gameOverPanel.SetActive(false);
    }
}
