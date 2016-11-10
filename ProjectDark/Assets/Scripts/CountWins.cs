using System;
using UnityEngine;
using UnityEngine.UI;

public class CountWins : MonoBehaviour
{
    public Text Player1WinCount;
    public Text Player2WinCount;
    public GameObject player1;
    public GameObject player2;

    private void Awake()
    {
        Player1WinCount.text = "0";
        Player2WinCount.text = "0";
    }

    public void IAmDead(string myName)
    {
        if(myName == "Player1")
        {
            UpdatePlayerWins(Player2WinCount);
        }
        if (myName == "Player2")
        {
            UpdatePlayerWins(Player1WinCount);
        }

        player1.SetActive(false);
        player2.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(true);
    }

    private void UpdatePlayerWins(Text playerCount)
    {
        var playerScore = Convert.ToInt32(playerCount.text);
        playerScore++;
        playerCount.text = playerScore.ToString();
    }
}
