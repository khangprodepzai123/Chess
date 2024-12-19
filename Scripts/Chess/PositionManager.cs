using UnityEngine;

public class PositionManager
{
    private ChessMan chessMan;

    public PositionManager(ChessMan chessMan)
    {
        this.chessMan = chessMan;
    }

    public void SetCoords()
    {
        // Lấy tọa độ từ ChessMan
        float x = chessMan.GetXBoard();
        float y = chessMan.GetYBoard();

        // Tính toán vị trí thực tế trên bàn cờ
        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        // Cập nhật vị trí của ChessMan
        chessMan.transform.position = new Vector3(x, y, -1.0f);

        // Kiểm tra điều kiện phong hậu
        if (chessMan.name == "white_pawn" && chessMan.GetYBoard() == 7)
        {
            chessMan.PromotePawn();
        }
        else if (chessMan.name == "black_pawn" && chessMan.GetYBoard() == 0)
        {
            chessMan.PromotePawn();
        }
    }
}


