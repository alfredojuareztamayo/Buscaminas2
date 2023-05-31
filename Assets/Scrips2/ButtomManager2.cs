using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Newtonsoft.Json.Bson;

public class ButtomManager2 : MonoBehaviour
{
    private GameManager2 GM;
    private GameObject main;
    private GameObject main4;
    private MenuManager menuManager;
    public TMP_Text m_Text;
    private string m_Content;
    private int x;
    private int y;
    private int level;
    private bool Visible;
    public bool WinLose ;
    int Tiles;
    void Start()
    {
        main4 = GameObject.Find("MenuManager");
        menuManager = main4.GetComponent<MenuManager>();
        main = GameObject.Find("Manager");
        GM = main.GetComponent<GameManager2>();
        m_Content = "";
        m_Text.text = m_Content;
        level = menuManager.T_Level;
        WinLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GM.FinallyQueue(x, y))
        //{
        //   // m_Text.text = GM.SetStringBoard(x, y);
        //   // Visible = false;
        //}
        Visible = GM.FinallyQueue(x, y, level);
        if (Visible)
        {
            m_Text.text = GM.SetStringBoard(x, y, level);
            //GM.TotalOfTiles--;
        }
        if (WinLose)
        {
            menuManager.Perdiste();
        }
        if(GM.TotalOfTiles == Tiles)
        {
            menuManager.Ganaste();
        }

    }
    public void SetCoords(int index, int size)
    {
       this.x = index / size;
       this.y = index % size;
    }
    public void ShowCoords()
    {
        Debug.Log("x: " + x + "y: " + y);
    }
    public void SetStringTile()
    {
        Debug.Log("x: " + x + "y: " + y);
        m_Text.text = GM.SetStringBoard(x, y, level);
        GM.QueueFinal(x,y, level);
        Tiles = GM.TilesLefts(level);
        WinLose = GM.GanasteONo(x, y, level);

        //GM.TotalOfTiles--;
    }
}
