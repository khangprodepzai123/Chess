using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : IActivate, IMoveStrategy
{
     public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_bishop : chessMan.white_bishop;
        chessMan.SetPlayer(color);
    }

     private IChessMove chessMove;

   
    public Bishop()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.LineMovePlate(chessMan,1, 1);
        chessMove.LineMovePlate(chessMan,1, -1);
        chessMove.LineMovePlate(chessMan,-1, 1);
        chessMove.LineMovePlate(chessMan,-1, -1);
        
    }
    
}
