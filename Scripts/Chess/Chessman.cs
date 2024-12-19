using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public  class ChessMan : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private Game gameController; // Tham chiếu đến lớp Game
    private TurnManager turnManager; // Quản lý lượt chơi
  


    private int xBoard = -1;
    private int yBoard = -1;
    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    

    protected string player;
    public string GetPlayer(){
        return player;
    }
    public void SetPlayer(string pl){
        player = pl;

    }
    private bool chieuvua = true;


    
   

    public Sprite black_queen, black_knight, black_bishop, black_king, black_rook, black_pawn;
    public Sprite white_queen, white_knight, white_bishop, white_king, white_rook, white_pawn;

    #region 
    private IMoveStrategy moveStrategy;
    public void SetMoveStrategy(IMoveStrategy strategy)
    {
        this.moveStrategy = strategy;
    }
    private IActivate activate;
    public void SetActivate(IActivate activate){
        this.activate = activate;
    }


    

    #endregion

    public  void Activate()
    {

        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();
       

        switch (this.name)
        {
            case "black_queen": SetActivate(new Queen()); break;
            case "black_knight": SetActivate(new Knight()); break;
            case "black_bishop": SetActivate(new Bishop()); break;
            case "black_king": SetActivate(new King()); break;
            case "black_rook": SetActivate(new Rook()); break;
            case "black_pawn": SetActivate(new BlackPawn()); break;
            case "white_queen": SetActivate(new Queen()); break;
            case "white_knight": SetActivate(new Knight()); break;
            case "white_bishop": SetActivate(new Bishop()); break;
            case "white_king": SetActivate(new King()); break;
            case "white_rook": SetActivate(new Rook()); break;
            case "white_pawn": SetActivate(new WhitePawn()); break;
        }
        activate?.Activate(this);
       

    }

    public void SetCoords()
    {
        
        float x = xBoard;
        float y = yBoard;

        
        x *= 0.66f;
        y *= 0.66f;

        
        x += -2.3f;
        y += -2.3f;

        
        this.transform.position = new Vector3(x, y, -1.0f);
        // Kiểm tra điều kiện phong hậu
    if (name == "white_pawn" && yBoard == 7)
    {
        PromotePawn();
    }
    else if (name == "black_pawn" && yBoard == 0)
    {
        PromotePawn();
    }
    }
    private void PromotePawn()
    {
    // Cập nhật sprite và vai trò thành quân hậu
    if (GetPlayer() == "white")
    {
        name = "white_queen";
        GetComponent<SpriteRenderer>().sprite = white_queen;
    }
    else if (GetPlayer() == "black")
    {
        name = "black_queen";
        GetComponent<SpriteRenderer>().sprite = black_queen;
    }

    // Cập nhật chiến thuật di chuyển mới cho quân hậu
    SetActivate(new Queen());
    SetMoveStrategy(new Queen());
    }
    

    private void OnMouseUp()
    {
       if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player && chieuvua)
        {
            //Remove all moveplates relating to previously selected piece
            DestroyMovePlates();

            //Create new MovePlates
            InitiateMovePlates();
        }
    }
    

    
 


    public void DestroyMovePlates()
    {
        //Destroy old MovePlates
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]); //Be careful with this function "Destroy" it is asynchronous
        }
    }
    
   
    public void InitiateMovePlates()
    {
        
        switch (this.name)
        {
            case "black_queen":
            case "white_queen":
                SetMoveStrategy(new Queen());
                break;
            case "black_knight":
            case "white_knight":
                SetMoveStrategy(new Knight());
                break;
            case "black_bishop":
            case "white_bishop":
                SetMoveStrategy(new Bishop());
                break;
            case "black_king":
            case "white_king":
                SetMoveStrategy(new King());
                break;
            case "black_rook":
            case "white_rook":
                SetMoveStrategy(new Rook());
                break;
            case "black_pawn":
                SetMoveStrategy(new BlackPawn());
                break;
            case "white_pawn":
               SetMoveStrategy(new WhitePawn());
                break;
        }
        moveStrategy?.ExecuteMovePlates(this);
       
       

       
        
    }


   


   




   
}*/


public  class ChessMan : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private Game gameController; // Tham chiếu đến lớp Game
    private PawnPromotionManager pawnPromotionManager;
    private PositionManager positionManager;
    private PieceActivator pieceActivator;
    private MovePlateManager movePlateManager;

    private IMoveStrategy moveStrategy;

     public IMoveStrategy GetMoveStrategy(){
        return moveStrategy;
    }
    public void SetMoveStrategy(IMoveStrategy strategy)
    {
        this.moveStrategy = strategy;
    }
    private IActivate activate;
    public IActivate GetActivate()
    {
        return activate;
    }

    public void SetActivate(IActivate activate){
        this.activate = activate;
    }
    private int xBoard = -1;
    private int yBoard = -1;
    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    

    protected string player;
    public string GetPlayer(){
        return player;
    }
    public void SetPlayer(string pl){
        player = pl;

    }
    private bool chieuvua = true;


    
   

    public Sprite black_queen, black_knight, black_bishop, black_king, black_rook, black_pawn;
    public Sprite white_queen, white_knight, white_bishop, white_king, white_rook, white_pawn;

    #region 

   

    

    #endregion
    
    void Awake()
    {
        // Khởi tạo PositionManager ngay khi ChessMan được tạo
        pawnPromotionManager = new PawnPromotionManager(white_queen, black_queen);
        positionManager = new PositionManager(this);
        pieceActivator = new PieceActivator(this);
        movePlateManager = new MovePlateManager();

    }


    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();
        pieceActivator.Activate();


    }

   



    public virtual void SetCoords()
    {
        
        positionManager.SetCoords();

    }
    public void PromotePawn()
    {
        pawnPromotionManager.PromotePawn(this);
    }
    

    private void OnMouseUp()
    {
       if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player && chieuvua)
        {
            //Remove all moveplates relating to previously selected piece
            DestroyMovePlates();

            //Create new MovePlates
            InitiateMovePlates();
        }
    }
 
    public void DestroyMovePlates(){
        movePlateManager.DestroyMovePlates();

    }
    
   
    
    public void InitiateMovePlates()
    {
        movePlateManager.InitiateMovePlates(this);
        
   
        
    }


   
}

