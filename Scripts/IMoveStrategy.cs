
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
   
    void ExecuteMovePlates(ChessMan chessMan);
}

/*public class QueenMoveStrategy : IMoveStrategy
{
    private IChessMove chessMove;
     public QueenMoveStrategy()
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

public class  KnightMoveStrategy : IMoveStrategy
{
    private IChessMove chessMove;

   
    public KnightMoveStrategy()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.LMovePlate(chessMan);
    }

}

public class BishopMoveStrategy : IMoveStrategy
{
    private IChessMove chessMove;

   
    public BishopMoveStrategy()
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

public class KingMoveStrategy : IMoveStrategy
{
     private IChessMove chessMove;

   
    public KingMoveStrategy()
    {
        chessMove = new ChessMoveImplementation();
    }
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.SurroundMovePlate(chessMan);
    }
}

public class RookMoveStrategy : IMoveStrategy
{
      private IChessMove chessMove;

   
    public RookMoveStrategy()
    {
        chessMove = new ChessMoveImplementation();
    }
    
    public void ExecuteMovePlates(ChessMan chessMan)
    {
        chessMove.LineMovePlate(chessMan,1, 0);
        chessMove.LineMovePlate(chessMan,0, 1);
        chessMove.LineMovePlate(chessMan,-1, 0);
        chessMove.LineMovePlate(chessMan,0, -1);

        
        
       
      
    }
}

public class BlackPawnMoveStrategy : IMoveStrategy 
{
    private IChessMove chessMove;

   
    public BlackPawnMoveStrategy()
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

public class WhitePawnMoveStrategy : IMoveStrategy 
{
     private IChessMove chessMove;

   
    public WhitePawnMoveStrategy()
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
}*/





