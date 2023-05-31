using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager2 : MonoBehaviour
{
    public TMP_Text bombsLeft;
    int Level;
    int Size;
    Board Tablero = new Board();
    private GameObject main2;
    private MenuManager menuManager;
    public GameObject Panel;
    public int TotalOfTiles;
    
    // Start is called before the first frame update
    void Start()
    {
        main2 = GameObject.Find("MenuManager");
        menuManager = main2.GetComponent<MenuManager>();
        Level = menuManager.T_Level;
        Size = menuManager.Size2;
        GridLayoutGroup g = Panel.GetComponent<GridLayoutGroup>();
        g.constraintCount = Size;
        Tablero.ChechLevel(Level);
        TotalOfTiles = (Size * Size) - Tablero.BombNum;
        //Tablero.PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        GetTheNumber();
    }
    public string SetStringBoard(int x, int y, int num)
    {
        return Tablero.NumbersOfBombsNear(x, y, num);
    }
    public bool FinallyQueue(int x, int y, int num)
    {
        return Tablero.SeeIfQueue(x, y,num);
    }
    public void QueueFinal(int x, int y, int num)
    {
        Tablero.AddQueue(x, y,Size,Size, num);
    }
    public void GetTheNumber()
    {
        bombsLeft.text = "Te faltan por descubrir: " + (TotalOfTiles-TilesLefts(Level)) + " islas";
        
    }
    public bool GanasteONo(int x, int y, int num)
    {
        return Tablero.WinLose(x, y, num);
    }
    public int TilesLefts(int num)
    {
        return Tablero.SeeWitchTileAreVisible(num);
    }
}
