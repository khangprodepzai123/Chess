using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceManager
{
    private GameObject chessPiecePrefab;

    public ChessPieceManager(GameObject prefab)
    {
        chessPiecePrefab = prefab;
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = GameObject.Instantiate(chessPiecePrefab, new Vector3(0, 0, -1), Quaternion.identity);
        ChessMan cm = obj.GetComponent<ChessMan>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }
}

