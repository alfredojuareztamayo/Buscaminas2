using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Newtonsoft.Json.Bson;

public class ButtomManager2 : MonoBehaviour
{
    private GameManager2 GM;
    private GameObject main;
    public TMP_Text m_Text;
    private string m_Content;
    private int x;
    private int y;
    private bool Visible;
    void Start()
    {
        main = GameObject.Find("Manager");
        GM = main.GetComponent<GameManager2>();
        m_Content = "";
        m_Text.text = m_Content;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.FinallyQueue(x, y))
        {
            m_Text.text = GM.SetStringBoard(x, y);
           // Visible = false;
        }
    }
    public void SetCoords(int index)
    {
        x = index / 10;
        y = index % 10;
    }
    public void ShowCoords()
    {
        Debug.Log("x: " + x + "y: " + y);
    }
    public void SetStringTile()
    {

       m_Text.text = GM.SetStringBoard(x, y);
        GM.QueueFinal(x, y);
         
    }
}
