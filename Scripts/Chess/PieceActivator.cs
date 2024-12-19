public class PieceActivator
{
    private ChessMan chessMan;

    public PieceActivator(ChessMan chessMan)
    {
        this.chessMan = chessMan;
    }

    public void Activate()
    {
        // Kiểm tra tên quân cờ và thiết lập chiến thuật di chuyển
        switch (chessMan.name)
        {
            case "black_queen":
                chessMan.SetActivate(new Queen());
                break;
            case "black_knight":
                chessMan.SetActivate(new Knight());
                break;
            case "black_bishop":
                chessMan.SetActivate(new Bishop());
                break;
            case "black_king":
                chessMan.SetActivate(new King());
                break;
            case "black_rook":
                chessMan.SetActivate(new Rook());
                break;
            case "black_pawn":
                chessMan.SetActivate(new BlackPawn());
                break;
            case "white_queen":
                chessMan.SetActivate(new Queen());
                break;
            case "white_knight":
                chessMan.SetActivate(new Knight());
                break;
            case "white_bishop":
                chessMan.SetActivate(new Bishop());
                break;
            case "white_king":
                chessMan.SetActivate(new King());
                break;
            case "white_rook":
                chessMan.SetActivate(new Rook());
                break;
            case "white_pawn":
                chessMan.SetActivate(new WhitePawn());
                break;
        }

        // Gọi phương thức Activate trên đối tượng IActivate
        chessMan.GetActivate()?.Activate(chessMan);
    }
}





