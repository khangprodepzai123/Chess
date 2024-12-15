using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivate
{
    void Activate(ChessMan chessMan);
}

/*
public class QueenActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_queen : chessMan.white_queen;
        chessMan.SetPlayer(color);
    }
}

public class KnightActivateStrategy : IActivate
{
  
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_knight : chessMan.white_knight;
        chessMan.SetPlayer(color);
    }
}

public class BishopActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_bishop : chessMan.white_bishop;
        chessMan.SetPlayer(color);
    }
}

public class KingActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_king : chessMan.white_king;
        chessMan.SetPlayer(color);
    }
}

public class RookActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        string color = chessMan.name.Contains("black") ? "black" : "white";
        chessMan.GetComponent<SpriteRenderer>().sprite = color == "black" ? chessMan.black_rook : chessMan.white_rook;
        chessMan.SetPlayer(color);
    }
}

public class BlackPawnActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        chessMan.GetComponent<SpriteRenderer>().sprite = chessMan.black_pawn;
        chessMan.SetPlayer("black");
    }
}

public class WhitePawnActivateStrategy : IActivate
{
    public void Activate(ChessMan chessMan)
    {
        chessMan.GetComponent<SpriteRenderer>().sprite = chessMan.white_pawn;
        chessMan.SetPlayer("white");
    }
}*/


