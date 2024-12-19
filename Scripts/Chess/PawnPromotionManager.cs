using UnityEngine;

/*public class PawnPromotionManager 
{
    private Sprite whiteQueenSprite;
    private Sprite blackQueenSprite;

    public PawnPromotionManager(Sprite whiteQueen, Sprite blackQueen)
    {
        whiteQueenSprite = whiteQueen;
        blackQueenSprite = blackQueen;
    }

    public void PromotePawn(ChessMan pawn)
    {
        // Cập nhật tên và sprite của quân cờ
        if (pawn.GetPlayer() == "white")
        {
            pawn.name = "white_queen";
            pawn.GetComponent<SpriteRenderer>().sprite = whiteQueenSprite;
        }
        else if (pawn.GetPlayer() == "black")
        {
            pawn.name = "black_queen";
            pawn.GetComponent<SpriteRenderer>().sprite = blackQueenSprite;
        }

        // Cập nhật chiến thuật di chuyển mới
        pawn.SetActivate(new Queen());
        pawn.SetMoveStrategy(new Queen());
    }
}*/

using System.Collections;
using System.Collections.Generic;

public class PawnPromotionManager : ChessMan
{
    private Sprite whiteQueenSprite;
    private Sprite blackQueenSprite;

    public PawnPromotionManager(Sprite whiteQueen, Sprite blackQueen)
    {
        this.whiteQueenSprite = whiteQueen;
        this.blackQueenSprite = blackQueen;
    }

    public void PromotePawn(ChessMan chessPiece)
    {
        // Cập nhật tên và sprite của quân cờ khi phong hậu
        if (chessPiece.GetPlayer() == "white")
        {
            chessPiece.name = "white_queen";
            chessPiece.GetComponent<SpriteRenderer>().sprite = whiteQueenSprite;
        }
        else if (chessPiece.GetPlayer() == "black")
        {
            chessPiece.name = "black_queen";
            chessPiece.GetComponent<SpriteRenderer>().sprite = blackQueenSprite;
        }

        // Cập nhật chiến thuật di chuyển thành quân hậu
        chessPiece.SetActivate(new Queen());
        chessPiece.SetMoveStrategy(new Queen());
    }

    // Ghi đè SetCoords nếu cần logic tùy chỉnh cho việc phong hậu
    public override void SetCoords()
    {
        base.SetCoords();

        // Kiểm tra điều kiện phong hậu
        if (name == "white_pawn" && GetYBoard() == 7)
        {
            PromotePawn(this);
        }
        else if (name == "black_pawn" && GetYBoard() == 0)
        {
            PromotePawn(this);
        }
    }
}


