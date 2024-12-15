using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePawn : IActivate, IMoveStrategy
{
     public void Activate(ChessMan chessMan)
    {
        chessMan.GetComponent<SpriteRenderer>().sprite = chessMan.white_pawn;
        chessMan.SetPlayer("white");
    }

    private IChessMove chessMove;

   
    public WhitePawn()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        if(chessMan.GetYBoard()==1)
        {
            chessMove.PawnMovePlate2(chessMan,chessMan.GetXBoard(), chessMan.GetYBoard() + 2);
            chessMove.PawnMovePlate(chessMan,chessMan.GetXBoard(), chessMan.GetYBoard() + 1);

        }else{
            chessMove.PawnMovePlate(chessMan,chessMan.GetXBoard(), chessMan.GetYBoard() + 1);
        }

        
        
    }
 
    
}
