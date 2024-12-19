using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager
{
    private string currentPlayer;
    private bool gameOver;

    public GameUIManager(string initialPlayer, bool isGameOver)
    {
        currentPlayer = initialPlayer;
        gameOver = isGameOver;
    }

    public void UpdatePlayerTurnUI()
    {
        GameObject playerTextObj = GameObject.FindGameObjectWithTag("PlayerText");
        if (playerTextObj != null)
        {
            Text playerText = playerTextObj.GetComponent<Text>();
            if (playerText != null)
            {
                playerText.text = currentPlayer == "white" ? "White Turn" : "Black Turn";
                return;
            }

            TextMeshProUGUI tmpText = playerTextObj.GetComponent<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.text = currentPlayer == "white" ? "White Turn" : "Black Turn";
                return;
            }

            Debug.LogError("No suitable text component found on the PlayerText GameObject!");
        }
        else
        {
            Debug.LogError("No GameObject with tag 'PlayerText' found in the scene!");
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;
        GameObject winnerTextObj = GameObject.FindGameObjectWithTag("WinnerText");
        GameObject restartTextObj = GameObject.FindGameObjectWithTag("RestartText");

        if (winnerTextObj != null)
        {
            Text winnerText = winnerTextObj.GetComponent<Text>();
            if (winnerText != null)
            {
                winnerText.enabled = true;
                winnerText.text = playerWinner + " is the winner";
            }
        }

        if (restartTextObj != null)
        {
            Text restartText = restartTextObj.GetComponent<Text>();
            if (restartText != null)
            {
                restartText.enabled = true;
            }
        }
    }

    public void SetCurrentPlayer(string player)
    {
        currentPlayer = player;
    }

    public void SetGameOver(bool isGameOver)
    {
        gameOver = isGameOver;
    }
}
