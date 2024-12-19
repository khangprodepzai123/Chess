using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardManager
{
    private GameObject[,] positions = new GameObject[8, 8];

    public bool PositionOnBoard(int x, int y)
    {
        return x >= 0 && y >= 0 && x < positions.GetLength(0) && y < positions.GetLength(1);
    }

    public GameObject GetPosition(int x, int y)
    {
        if (PositionOnBoard(x, y))
        {
            return positions[x, y];
        }
        return null;
    }

    public void SetPosition(GameObject obj, int x, int y)
    {
        if (PositionOnBoard(x, y))
        {
            positions[x, y] = obj;
        }
    }

    public void SetPositionEmpty(int x, int y)
    {
        if (PositionOnBoard(x, y))
        {
            positions[x, y] = null;
        }
    }
}
