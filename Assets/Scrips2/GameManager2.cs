using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    Board Tablero = new Board();
    // Start is called before the first frame update
    void Start()
    {
        Tablero.GenerateBoard();
        Tablero.PrintArray(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string SetStringBoard(int x, int y)
    {
        return Tablero.NumbersOfBombsNear(x, y);
    }
    public bool FinallyQueue(int x, int y)
    {
        return Tablero.SeeIfQueue(x, y);
    }
    public void QueueFinal(int x, int y)
    {
        Tablero.AddQueue(x, y);
    }
}
