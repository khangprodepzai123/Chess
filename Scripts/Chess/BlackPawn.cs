using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawn : IActivate, IMoveStrategy
{
     public void Activate(ChessMan chessMan)
    {
        chessMan.GetComponent<SpriteRenderer>().sprite = chessMan.black_pawn;
        chessMan.SetPlayer("black");
    }

    private IChessMove chessMove;

   
    public BlackPawn()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        if(chessMan.GetYBoard()==6)
        {
            chessMove.PawnMovePlate(chessMan, chessMan.GetXBoard(), chessMan.GetYBoard() - 1);
            chessMove.PawnMovePlate2(chessMan, chessMan.GetXBoard(), chessMan.GetYBoard() - 2);

        }else{
            chessMove.PawnMovePlate(chessMan, chessMan.GetXBoard(), chessMan.GetYBoard() - 1);
        }
       
    }
    
}
