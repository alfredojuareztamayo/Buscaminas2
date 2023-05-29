using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    int numTiles = Board.boardColumns * Board.boardRows;
    public GameObject Buttom;
    public Transform Parent;
    void Start()
    {
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
