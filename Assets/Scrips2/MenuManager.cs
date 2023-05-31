using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int T_Level;
    public GameObject panleInicial;
    public GameObject DifficultPanel;
    public int Size2;

    void Start()
    {
       // panleInicial = GameObject.Find("PanelInicio");
        //DifficultPanel = GameObject.Find("DificultPanle");
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevel()
    {
        panleInicial.SetActive(false);
        DifficultPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        DifficultPanel.SetActive(false);
        panleInicial.SetActive(true);
        
    }
    public void SeeYou()
    {
        Application.Quit();
    }
    public void LevelEasy()
    {
        T_Level = 0;
        SceneManager.LoadScene("MainBuscaMinas");
        Size2 = Board.boardColumns;
    }
    public void LevelMedium()
    {
        T_Level = 1;
        SceneManager.LoadScene("MainBuscaMinas");
        Size2 = Board.boardRowsMedium;
    }
    public void HardLevel()
    {
        T_Level = 2;
        SceneManager.LoadScene("MainBuscaMinas");
        Size2 = Board.boardRowsHard;
    }
}
