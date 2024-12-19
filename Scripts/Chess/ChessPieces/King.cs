using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : IActivate, IMoveStrategy
{
     public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_king : chessMan.white_king;
        chessMan.SetPlayer(color);
    }

     private IChessMove chessMove;

   
    public King()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.SurroundMovePlate(chessMan);
    }
    
}
