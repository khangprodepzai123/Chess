using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : IActivate, IMoveStrategy
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_knight : chessMan.white_knight;
        chessMan.SetPlayer(color);
    }
   private IChessMove chessMove;

   
    public Knight()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.LMovePlate(chessMan);
    }
    
    
}
