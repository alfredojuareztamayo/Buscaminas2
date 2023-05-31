using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Board
{
    Stack<Tile> Bombitas = new();
    Queue<Tile> QueueBombs = new Queue<Tile>();
    public const int boardRowsMedium = 12;
    public const int boardColumnsMedium = 12;
    public const int boardRowsHard = 13;
    public const int boardColumnsHard = 13;
    public const int boardRows = 10;
    public const int boardColumns = 10;
    public Tile[,] tile = new Tile[boardRows, boardColumns];
    public Tile[,] tile2 = new Tile[boardRowsMedium, boardColumnsMedium];
    public Tile[,] tile3 = new Tile[boardRowsHard, boardColumnsHard];
    int CheckTile;
    public int BombNum { get; private set; } = 8;
   // public GameObject[] TilesAndBoard; 


    public void ChechLevel(int lvl)
    {
        switch (lvl)
        {
            case 0:
                GenerateBoard(tile, boardRows, boardColumns);
                CheckTile = 0;
                AddToStack(tile, boardRows, boardColumns);
                break; 
            case 1:
                GenerateBoard(tile2, boardRowsMedium, boardColumnsMedium);
                CheckTile = 1;
                AddToStack(tile2, boardRowsMedium, boardColumnsMedium);
                break;
            case 2:
                GenerateBoard(tile3, boardRowsHard, boardColumnsHard);
                CheckTile = 2;
                AddToStack(tile3, boardRowsHard, boardColumnsHard);
                break;
        }
    }
    /// <summary>
    /// Generates the game board by randomly placing bombs and non-bomb tiles.
    /// </summary>
    public void GenerateBoard(Tile[,] temp, int tempRow, int TempColum)
    {
       // Tile tmp = 
        int tempBomb = BombNum;
        int tilesLeft = tempRow * TempColum;
       

        for (int i = 0; i < tempRow; i++)
        {
            
            for (int j = 0; j < TempColum; j++)
            {
;
                int random = Random.Range(0, 5);
                if (tilesLeft == tempBomb)
                {
                    temp[i, j] = new Tile(true);
                    tempBomb--;
                }
                else
                {
                    if (tempBomb > 0 & random == 1)
                    {
                        temp[i, j] = new Tile(true);
                        tempBomb--;
                    }
                    else
                    {
                        temp[i, j] = new Tile(false);
                    }
                }
                temp[i, j].AddX(i);
                temp[i, j].Addy(j);
                tilesLeft--;
             
            }

        
        }
        
    }

    /// <summary>
    /// Prints the game board to the console.
    /// </summary>
    //public void PrintArray()
    //{
    //    string printArray = " ";
    //    for (int i = 0; i < boardRows; i++)
    //    {
    //        for (int j = 0; j < boardColumns; j++)
    //        {
    //            if (tile[i, j].BomboN)
    //            {
    //                printArray += 'B';
    //            }
    //            else
    //            {
    //                printArray += tile[i, j].BombsNear;
    //            }
    //            printArray += ',';
    //        }
    //        printArray += '\n';
    //    }
    //    Debug.Log(printArray);
    //}

    /// <summary>
    /// Adds bomb tiles to the stack and checks their surrounding tiles.
    /// </summary>
    public void AddToStack(Tile[,] temp, int TempRow, int TempColu)
    {
        for (int i = 0; i < TempRow; i++)
        {
            for (int j = 0; j < TempColu; j++)
            {
                if (!temp[i, j].BomboN) continue;
                Checksurroundind(temp,i, j, TempRow, TempColu);

            }
        }
    }

    /// <summary>
    /// Checks the surrounding tiles of a given position and adds them to the stack if they are not bomb tiles.
    /// </summary>
    public void Checksurroundind(Tile[,] temp, int i, int j, int TempRow, int TempColu)
    {
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x < 0) continue;
                if (y < 0) continue;
                if (x >= TempColu) continue;
                if (y >= TempRow) continue;
                if (temp[x, y].BomboN) continue;
                Bombitas.Push(temp[x, y]);
                temp[x, y].Visible();
            }
        }
        AddCounterBombs();
    }

    /// <summary>
    /// Adds the bombs near a tile by incrementing the BombsNear counter of each surrounding non-bomb tile.
    /// </summary>
    public void AddCounterBombs()
    {
        while (Bombitas.Count > 0)
        {
            Bombitas.Pop().AddBombsNear();
        }
    }

    /// <summary>
    /// Sets a the bombs near like a string and if its a bomb the string is B
    /// </summary>
    public string NumbersOfBombsNear(int x, int y)
    {
        Tile[,] tempT = WitchTile();
        
        if(tempT[x, y].BomboN)
        {
            // Debug.Log("Soy bomba");
            //Debug.Log("X: " + tile[x, y].X + "Y :" + tile[x, y].Y);
            return "B";
        }
        else
        {
            //  Debug.Log("Soy num");

            //Debug.Log("X: " + tile[x, y].X + "Y :" + tile[x, y].Y);
            return tempT[x, y].BombsNear.ToString();

        }
        
    }
    public Tile[,] WitchTile()
    {
        switch (CheckTile)
        {
            case 0:
                Tile[,] temp = tile;
                return temp;
                
                case 1:
                Tile[,] temp2 = tile2;
                return temp2;
               
            case 2:
                Tile[,] temp3 = tile3;
                return temp3;
        }
        return null;
    }
    public bool SeeIfQueue(int x, int y)
    {
        Tile[,] tempT = WitchTile();
        return tempT[x, y].InQueue;
    }
    public void AddQueue(int x, int y, int TempRow, int TempColu)
    {
        Tile[,] tempT = WitchTile();
        if (tempT[x,y].BombsNear == 0 && !tempT[x,y].BomboN)
        {
            ChecksurroundindQueue(x, y, TempRow, TempColu);
        }
        else if (tempT[x, y].BombsNear != 0 /*&& !tile[x, y].InQueue*/)
        {
            Debug.Log("ji");
            
        }
        
    }
    // <summary>
    // Checks the surrounding tiles of a given position and adds them to the queue if they are not bomb tiles.
    // </summary>
    public void ChecksurroundindQueue(int i, int j, int TempRow, int TempColu)
    {

        Tile[,] tempT = WitchTile();
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x < 0) continue;
                if (y < 0) continue;
                if (x >= TempColu) continue;
                if (y >= TempRow) continue;
               // if (tile[x, y].BombsNear != 0) continue;
                if (tempT[x, y].BomboN) continue;
                if (tempT[x, y].InQueue) continue;
                QueueBombs.Enqueue(tempT[x, y]);
                tempT[x, y].InQueueNum(true);


            }
        }
        AddBoolQueue( TempRow,  TempColu);
    }
    public void AddBoolQueue(int TempRow, int TempColu)
    {
       Tile[,] tempT = WitchTile();
        while (QueueBombs.Count > 0)
        {
            Debug.Log(QueueBombs.Count);
            Tile temp = QueueBombs.Dequeue();
            if (tempT[temp.X, temp.Y].BombsNear != 0) continue;
             ChecksurroundindQueue(temp.X, temp.Y, TempRow, TempColu);
           
        }
    }

    public void SetNumberOfBombs(int num)
    {
        BombNum = num;
    }
    public int GetNumberBombs()
    {
       return BombNum;
    }

    /// <summary>
    /// Sets the bomb and non-bomb tile texts in a UI element.
    /// </summary>
    //public void SetBombsTest(Transform parent)
    //{
    //    TMP_Text m_text;
    //    Transform p = parent;
    //    int child = 0;

    //    for (int i = 0; i < boardRows; i++)
    //    {
    //        for (int j = 0; j < boardColumns; j++)
    //        {

    //            m_text = p.GetChild(child).GetComponentInChildren<TMP_Text>();

    //            if (tile[i, j].BomboN)
    //            {
    //                m_text.text = "B";

    //            }
    //            else
    //            {
    //                m_text.text = tile[i, j].BombsNear.ToString();
    //            }
    //            child++;
    //        }

    //    }
    //}

    /// <summary>
    /// Turns off the text tiles in a UI element.
    /// </summary>
    //public void TurnOffTextTile(Transform parent)
    //{
    //    GameObject g;
    //    foreach (Transform child in parent)
    //    {
    //        g = child.Find("TextTag").gameObject;
    //        g.SetActive(false);
    //    }
    //}

    /// <summary>
    /// Checks the win or lose condition based on a tile's properties.
    /// </summary>
    //public void WinLoseCondition(int x, int y, Transform h)
    //{
    //    Transform H = h;
    //    // Debug.Log($"{tile[x, y].BombsNear} + {tile[x, y].BomboN}");
    //    if (tile[x, y].BomboN)
    //    {
    //        Debug.Log("Perdiste");
    //    }
    //    else if (tile[x, y].BombsNear == 0 )
    //    {
    //        ChecksurroundindQueue(x, y, H);
    //    }
    //    else
    //    {
    //        Debug.Log(tile[x, y].BombsNear);
    //    }

    //}
    /// <summary>
    ///  Adds tiles to the queue and checks their surrounding tiles. if the number is 0
    /// </summary>
    //public void AddToQueue(int i, int j, Transform h)
    //{
    //    Transform H = h;
    //    if (tile[i, j].BombsNear == 0 && !tile[i, j].InQueue)
    //    {

    //    }


    //}
    /// <summary>
    /// Checks the surrounding tiles of a given position and adds them to the queue if they are not bomb tiles.
    /// </summary>
    //public void ChecksurroundindQueue(int i, int j, Transform h)
    //{
    //    Transform H = h;
    //    for (int x = i - 1; x <= i + 1; x++)
    //    {
    //        for (int y = j - 1; y <= j + 1; y++)
    //        {
    //            if (x < 0) continue;
    //            if (y < 0) continue;
    //            if (x >= boardColumns) continue;
    //            if (y >= boardRows) continue;
    //         // if (tile[x, y].BombsNear == 0) continue;
    //            if (tile[x, y].BomboN) continue;
    //            if(!tile[x, y].InQueue) continue;
    //            QueueBombs.Enqueue(tile[x, y]);
    //            tile[x, y].InQueueNum();


    //        }
    //    }

    //    TurnTheQueue(H);
    //}

    /// <summary>
    /// Adds the bombs near a tile by incrementing the BombsNear counter of each surrounding non-bomb tile.
    /// </summary>
    //public void AddBoolQueue()
    //{
    //    while (QueueBombs.Count > 0)
    //    {

    //        QueueBombs.Dequeue().InQueueNum();
    //    }
    //}



    /// <summary>
    /// Checks if the gameObject is in the queue.
    /// </summary>
    //public void TurnTheQueue(Transform h)
    //{

    //    GameObject g;
    //    int z;


    //    while (QueueBombs.Count > 0)
    //    {
    //        Tile temp = QueueBombs.Dequeue();
    //        z = (temp.X * boardRows) + temp.Y;
    //        Debug.Log(z);
    //        g = h.GetChild(z).Find("TextTag").gameObject;
    //        g.SetActive(true);
    //        WinLoseCondition(temp.X, temp.Y, h);
    //       // AddToQueue(temp.X, temp.Y,h);
    //    }






    //}
}

