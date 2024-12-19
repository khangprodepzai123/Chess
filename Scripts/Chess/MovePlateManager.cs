using UnityEngine;

public class MovePlateManager
{
    // Hàm hủy các MovePlates cũ
    public void DestroyMovePlates()
    {
        // Tìm tất cả GameObject có tag là "MovePlate"
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        
        // Duyệt qua tất cả MovePlates và hủy chúng
        for (int i = 0; i < movePlates.Length; i++)
        {
            // Cẩn thận với phương thức "Destroy" vì nó là bất đồng bộ
            GameObject.Destroy(movePlates[i]);
        }
    }


     public void InitiateMovePlates(ChessMan chessMan)
    {
        // Kiểm tra tên quân cờ và thiết lập chiến lược di chuyển
        switch (chessMan.name)
        {
            case "black_queen":
            case "white_queen":
                chessMan.SetMoveStrategy(new Queen());
                break;
            case "black_knight":
            case "white_knight":
                chessMan.SetMoveStrategy(new Knight());
                break;
            case "black_bishop":
            case "white_bishop":
                chessMan.SetMoveStrategy(new Bishop());
                break;
            case "black_king":
            case "white_king":
                chessMan.SetMoveStrategy(new King());
                break;
            case "black_rook":
            case "white_rook":
                chessMan.SetMoveStrategy(new Rook());
                break;
            case "black_pawn":
                chessMan.SetMoveStrategy(new BlackPawn());
                break;
            case "white_pawn":
                chessMan.SetMoveStrategy(new WhitePawn());
                break;
        }

        // Thực thi chiến lược di chuyển và tạo MovePlates
        chessMan.GetMoveStrategy()?.ExecuteMovePlates(chessMan);
    }
}
