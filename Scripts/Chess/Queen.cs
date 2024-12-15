using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : IActivate, IMoveStrategy
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_queen : chessMan.white_queen;
        chessMan.SetPlayer(color);
    }
     private IChessMove chessMove;
     public Queen()
    {
        chessMove = new ChessMoveImplementation();  
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.LineMovePlate(chessMan, 1, 0);
        chessMove.LineMovePlate(chessMan, 0, 1);
        chessMove.LineMovePlate(chessMan, 1, 1);
        chessMove.LineMovePlate(chessMan, -1, 0);
        chessMove.LineMovePlate(chessMan, 0, -1);
        chessMove.LineMovePlate(chessMan, -1, -1);
        chessMove.LineMovePlate(chessMan, -1, 1);
        chessMove.LineMovePlate(chessMan, 1, -1);

    }
    
}
