using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



/*public class Game : MonoBehaviour
{
   

    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    [SerializeField ]private Timer timer;
    
   



    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
    
        playerWhite = new GameObject[] { Create("white_rook", 0, 0), Create("white_knight", 1, 0),
            Create("white_bishop", 2, 0), Create("white_queen", 3, 0), Create("white_king", 4, 0),
            Create("white_bishop", 5, 0), Create("white_knight", 6, 0), Create("white_rook", 7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
            Create("white_pawn", 3, 1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1) };
        playerBlack = new GameObject[] { Create("black_rook", 0, 7), Create("black_knight",1,7),
            Create("black_bishop",2,7), Create("black_queen",3,7), Create("black_king",4,7),
            Create("black_bishop",5,7), Create("black_knight",6,7), Create("black_rook",7,7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
            Create("black_pawn", 3, 6), Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6) };

        
        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
        
        
    }
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessMan cm = obj.GetComponent<ChessMan>(); 
        cm.name = name; 
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate(); 
        return obj;
    }

     public void SetPosition(GameObject obj)
    {
        ChessMan cm = obj.GetComponent<ChessMan>();

     
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

     public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white" )
        {
            currentPlayer = "black";
           
        }
        else
        {
            currentPlayer = "white";
            

        }

        timer.ResetTime();
        UpdatePlayerTurnUI();
      
        
    

        
    }
    private void UpdatePlayerTurnUI()
{
    GameObject playerTextObj = GameObject.FindGameObjectWithTag("PlayerText");
    if (playerTextObj != null)
    {
        // Kiểm tra nếu là Text thường
        Text playerText = playerTextObj.GetComponent<Text>();
        if (playerText != null)
        {
            playerText.text = currentPlayer == "white" ? "White Turn" : "Black Turn";
            return; // Nếu đã tìm thấy và cập nhật thì dừng hàm
        }

        // Kiểm tra nếu là TextMeshProUGUI
        TextMeshProUGUI tmpText = playerTextObj.GetComponent<TextMeshProUGUI>();
        if (tmpText != null)
        {
            tmpText.text = currentPlayer == "white" ? "White Turn" : "Black Turn";
            return;
        }

        Debug.LogError("No suitable text component found on the PlayerText GameObject!");
    }
    else
    {
        Debug.LogError("No GameObject with tag 'PlayerText' found in the scene!");
    }
}



    public void Update()
    {
         if (timer.remainingTime <= 0)
    {
        Winner(currentPlayer == "white" ? "black" : "white");
        //return; // Tránh tiếp tục Update khi đã gọi Winner
    }
       
        if (gameOver == true && Input.GetMouseButtonDown(0) )
        {
            gameOver = false;

            //Using UnityEngine.SceneManagement is needed here
            SceneManager.LoadScene("Game"); //Restarts the game by loading the scene over again
        }
       
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        //Using UnityEngine.UI is needed here
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }

    
}*/


public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private ChessBoardManager boardManager = new ChessBoardManager(); // Using ChessBoardManager

    private GameUIManager uiManager;

    //private TurnManager turnManager;


    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    [SerializeField] private Timer timer;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //
        uiManager = new GameUIManager(currentPlayer, gameOver);
        //turnManager = new TurnManager(currentPlayer, timer, uiManager);
        


        playerWhite = new GameObject[] {
            Create("white_rook", 0, 0), Create("white_knight", 1, 0),
            Create("white_bishop", 2, 0), Create("white_queen", 3, 0),
            Create("white_king", 4, 0), Create("white_bishop", 5, 0),
            Create("white_knight", 6, 0), Create("white_rook", 7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1),
            Create("white_pawn", 2, 1), Create("white_pawn", 3, 1),
            Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1)
        };

        playerBlack = new GameObject[] {
            Create("black_rook", 0, 7), Create("black_knight", 1, 7),
            Create("black_bishop", 2, 7), Create("black_queen", 3, 7),
            Create("black_king", 4, 7), Create("black_bishop", 5, 7),
            Create("black_knight", 6, 7), Create("black_rook", 7, 7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6),
            Create("black_pawn", 2, 6), Create("black_pawn", 3, 6),
            Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6)
        };

        for (int i = 0; i < playerBlack.Length; i++)
        {
            boardManager.SetPosition(playerBlack[i], playerBlack[i].GetComponent<ChessMan>().GetXBoard(), playerBlack[i].GetComponent<ChessMan>().GetYBoard());
            boardManager.SetPosition(playerWhite[i], playerWhite[i].GetComponent<ChessMan>().GetXBoard(), playerWhite[i].GetComponent<ChessMan>().GetYBoard());
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessMan cm = obj.GetComponent<ChessMan>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public GameObject GetPosition(int x, int y)
    {
        return boardManager.GetPosition(x, y);
    }

    public void SetPosition(GameObject obj, int x, int y)
    {
        boardManager.SetPosition(obj, x, y);
    }

    public void SetPositionEmpty(int x, int y)
    {
        boardManager.SetPositionEmpty(x, y);
    }

    public bool PositionOnBoard(int x, int y)
    {
        return boardManager.PositionOnBoard(x, y);
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        currentPlayer = currentPlayer == "white" ? "black" : "white";
        timer.ResetTime();
        //
        uiManager.SetCurrentPlayer(currentPlayer);
        uiManager.UpdatePlayerTurnUI();
       
    }

    

    public void Update()
    {
        if (timer.remainingTime <= 0)
        {
            Winner(currentPlayer == "white" ? "black" : "white");
        }

        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;
            SceneManager.LoadScene("Game");
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;
        uiManager.SetGameOver(gameOver);
        uiManager.Winner(playerWinner);
    }
}


