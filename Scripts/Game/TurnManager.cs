using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : Game
{
    private string currentPlayer="white" ;
    private Timer timer;
    private GameUIManager uiManager;
    public TurnManager(string currentPlayer, Timer timer, GameUIManager uiManager){
        this.currentPlayer = currentPlayer; // Gán giá trị tham số vào thuộc tính
        this.timer = timer;
        this.uiManager = uiManager;
       

        

    }

    public void Next()
    {
        currentPlayer = currentPlayer == "white" ? "black" : "white";
        timer.ResetTime();
        //
        uiManager.SetCurrentPlayer(currentPlayer);
        uiManager.UpdatePlayerTurnUI();
    }
}

