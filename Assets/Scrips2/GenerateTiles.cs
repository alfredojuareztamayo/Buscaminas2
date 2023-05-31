using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    //int Size;
    private GameObject main3;
    private MenuManager menuManager;
    int numTiles;
    public GameObject Buttom;
    public Transform Parent;
    void Start()
    {
        main3 = GameObject.Find("MenuManager");
        menuManager = main3.GetComponent<MenuManager>();
        numTiles = menuManager.Size2 * menuManager.Size2;
        GenerateButtoms();
    }
    
    public void GenerateButtoms()
    {
        for (int i = 0; i < numTiles ; i++)
        {
           GameObject Temp = Instantiate(Buttom, Parent);
            
            if(!Temp.TryGetComponent<ButtomManager2>(out ButtomManager2 buttomManager2))
            {
                buttomManager2 = Temp.AddComponent<ButtomManager2>();
            }
            buttomManager2.SetCoords(i);
        }
    }
 
}
