using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChessMove
{
    void LineMovePlate(ChessMan chessMan, int xIncrement, int yIncrement);
    void LMovePlate(ChessMan chessMan);
    void SurroundMovePlate(ChessMan chessMan);
    void PointMovePlate(ChessMan chessMan, int x, int y);
    void PawnMovePlate(ChessMan chessMan, int x, int y);
    void PawnMovePlate2(ChessMan chessMan, int x, int y);
    void MovePlateSpawn(ChessMan chessMan, int matrixX, int matrixY);
    void MovePlateAttackSpawn(ChessMan chessMan, int matrixX, int matrixY);

    void WhiteCastle(ChessMan chessMan);
}

public class ChessMoveImplementation : IChessMove
{
    public void LineMovePlate(ChessMan chessMan, int xIncrement, int yIncrement)
    {
        Game sc = chessMan.controller.GetComponent<Game>();

        int x = chessMan.GetXBoard() + xIncrement;
        int y = chessMan.GetYBoard() + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(chessMan, x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<ChessMan>().GetPlayer() != chessMan.GetPlayer())
        {
            MovePlateAttackSpawn(chessMan, x, y);
        }

    }

    public void LMovePlate(ChessMan chessMan)
    {
        PointMovePlate(chessMan, chessMan.GetXBoard() + 1, chessMan.GetYBoard() + 2);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 1, chessMan.GetYBoard() + 2);
        PointMovePlate(chessMan, chessMan.GetXBoard() + 2, chessMan.GetYBoard() + 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() + 2, chessMan.GetYBoard() - 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() + 1, chessMan.GetYBoard() - 2);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 1, chessMan.GetYBoard() - 2);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 2, chessMan.GetYBoard() + 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 2, chessMan.GetYBoard() - 1);
    }

    public void SurroundMovePlate(ChessMan chessMan)
    {
        PointMovePlate(chessMan, chessMan.GetXBoard(), chessMan.GetYBoard() + 1);
        PointMovePlate(chessMan, chessMan.GetXBoard(), chessMan.GetYBoard() - 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 1, chessMan.GetYBoard());
        PointMovePlate(chessMan, chessMan.GetXBoard() - 1, chessMan.GetYBoard() - 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() - 1, chessMan.GetYBoard() + 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() + 1, chessMan.GetYBoard());
        PointMovePlate(chessMan, chessMan.GetXBoard() + 1, chessMan.GetYBoard() - 1);
        PointMovePlate(chessMan, chessMan.GetXBoard() + 1, chessMan.GetYBoard() + 1);
    }

    public void PointMovePlate(ChessMan chessMan, int x, int y)
    {
        Game sc = chessMan.controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(chessMan, x, y);
            }
            else if (cp.GetComponent<ChessMan>().GetPlayer() != chessMan.GetPlayer())
            {
                MovePlateAttackSpawn(chessMan, x, y);
            }
        }
    }


    public void PawnMovePlate(ChessMan chessMan, int x, int y)
    {
        Game sc = chessMan.controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(chessMan, x, y);
            }

            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<ChessMan>().GetPlayer() != chessMan.GetPlayer())
            {
                MovePlateAttackSpawn(chessMan, x + 1, y);
            }

            if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<ChessMan>().GetPlayer() != chessMan.GetPlayer())
            {
                MovePlateAttackSpawn(chessMan, x - 1, y);
            }
        }
    }
     public void PawnMovePlate2(ChessMan chessMan, int x, int y)
    {
        Game sc = chessMan.controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(chessMan, x, y);
            }
        }
    }


    public void MovePlateSpawn(ChessMan chessMan, int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Object.Instantiate(chessMan.movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(chessMan.gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(ChessMan chessMan, int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Object.Instantiate(chessMan.movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(chessMan.gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    /*public void WhiteCastle(ChessMan chessMan, int x, int y)
    {
    Game sc = chessMan.controller.GetComponent<Game>();

    // Vị trí ban đầu của vua và xe trắng
    if (chessMan.GetXBoard() == 4 && chessMan.GetYBoard() == 0)
    {
        // Nhập thành cánh vua (King-side castle)
        if (sc.GetPosition(7, 0) != null && sc.GetPosition(7, 0).GetComponent<ChessMan>().name == "white_rook")
        {
            if (sc.GetPosition(5, 0) == null && sc.GetPosition(6, 0) == null)
            {
                // Thực hiện di chuyển nhập thành
                MovePlateSpawn(chessMan, 6, 0); // Di chuyển vua đến vị trí nhập thành
                MovePlateSpawn(sc.GetPosition(7, 0).GetComponent<ChessMan>(), 5, 0); // Di chuyển xe
            }
        }

        // Nhập thành cánh hậu (Queen-side castle)
        if (sc.GetPosition(0, 0) != null && sc.GetPosition(0, 0).GetComponent<ChessMan>().name == "white_rook")
        {
            if (sc.GetPosition(1, 0) == null && sc.GetPosition(2, 0) == null && sc.GetPosition(3, 0) == null)
            {
                // Thực hiện di chuyển nhập thành
                MovePlateSpawn(chessMan, 2, 0); // Di chuyển vua đến vị trí nhập thành
                MovePlateSpawn(sc.GetPosition(0, 0).GetComponent<ChessMan>(), 3, 0); // Di chuyển xe
            }
        }
    }
    }*/
    public void WhiteCastle(ChessMan chessMan)
    {
        Game sc = chessMan.controller.GetComponent<Game>();
        if(sc.GetPosition(0,0)!=null && sc.GetPosition(1, 0)==null && sc.GetPosition(2,0)==null && sc.GetPosition(3, 0)==null && sc.GetPosition(4,0)!=null){
            MovePlateSpawn(chessMan, 2,0);
            MovePlateSpawn(chessMan, 3,0);
        }
       
    }


    
    
}
