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
        //Tablero.PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        GetTheNumber();
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
        Tablero.AddQueue(x, y,Size,Size);
    }
    public void GetTheNumber()
    {
        bombsLeft.text = "Ilan Oro Manco";//+ Tablero.GetNumberBombs().ToString();
        
    }
}
