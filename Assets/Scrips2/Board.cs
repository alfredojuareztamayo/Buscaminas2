using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Board
{
    Stack<Tile> Bombitas = new();
    Queue<Tile> QueueBombs = new Queue<Tile>();
    public const int boardRows = 10;
    public const int boardColumns = 10;
    public Tile[,] tile = new Tile[boardRows, boardColumns];
    public int BombNum { get; private set; } = 10;
   // public GameObject[] TilesAndBoard; 

    /// <summary>
    /// Generates the game board by randomly placing bombs and non-bomb tiles.
    /// </summary>
    public void GenerateBoard()
    {
        int tempBomb = BombNum;
        int tilesLeft = boardColumns * boardRows;
       

        for (int i = 0; i < boardRows; i++)
        {
            
            for (int j = 0; j < boardColumns; j++)
            {
;
                int random = Random.Range(0, 5);
                if (tilesLeft == tempBomb)
                {
                    tile[i, j] = new Tile(true);
                    tempBomb--;
                }
                else
                {
                    if (tempBomb > 0 & random == 1)
                    {
                        tile[i, j] = new Tile(true);
                        tempBomb--;
                    }
                    else
                    {
                        tile[i, j] = new Tile(false);
                    }
                }
                tile[i, j].AddX(j);
                tile[i, j].Addy(i);
                tilesLeft--;
             
            }

        
        }

        AddToStack();
        
    }

    /// <summary>
    /// Prints the game board to the console.
    /// </summary>
    public void PrintArray()
    {
        string printArray = " ";
        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                if (tile[i, j].BomboN)
                {
                    printArray += 'B';
                }
                else
                {
                    printArray += tile[i, j].BombsNear;
                }
                printArray += ',';
            }
            printArray += '\n';
        }
        Debug.Log(printArray);
    }

    /// <summary>
    /// Adds bomb tiles to the stack and checks their surrounding tiles.
    /// </summary>
    public void AddToStack()
    {
        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                if (!tile[i, j].BomboN) continue;
                Checksurroundind(i, j);

            }
        }
    }

    /// <summary>
    /// Checks the surrounding tiles of a given position and adds them to the stack if they are not bomb tiles.
    /// </summary>
    public void Checksurroundind(int i, int j)
    {
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x < 0) continue;
                if (y < 0) continue;
                if (x >= boardColumns) continue;
                if (y >= boardRows) continue;
                if (tile[x, y].BomboN) continue;
                Bombitas.Push(tile[x, y]);
                tile[x, y].Visible();
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
        
        if(tile[x, y].BomboN)
        {
           // Debug.Log("Soy bomba");
            return "B";
        }
        else
        {
          //  Debug.Log("Soy num");
            return tile[x, y].BombsNear.ToString();
        }
        
    }
    public bool SeeIfQueue(int x, int y)
    {
        return tile[x, y].InQueue;
    }
    public void AddQueue(int x, int y)
    {
        if (tile[x,y].BombsNear == 0 && !tile[x,y].BomboN)
        {
            ChecksurroundindQueue( x,  y);
        }
        else if (tile[x, y].BombsNear != 0 /*&& !tile[x, y].InQueue*/)
        {
            Debug.Log("ji");
        }
        
    }
    // <summary>
    // Checks the surrounding tiles of a given position and adds them to the queue if they are not bomb tiles.
    // </summary>
    public void ChecksurroundindQueue(int i, int j)
    {
      
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x < 0) continue;
                if (y < 0) continue;
                if (x >= boardColumns) continue;
                if (y >= boardRows) continue;
               // if (tile[x, y].BombsNear != 0) continue;
                if (tile[x, y].BomboN) continue;
                if (tile[x, y].InQueue) continue;
                QueueBombs.Enqueue(tile[x, y]);
                tile[x, y].InQueueNum(true);


            }
        }
        AddBoolQueue();
    }
    public void AddBoolQueue()
    {
        while (QueueBombs.Count > 0)
        {

            Tile temp = QueueBombs.Dequeue();
            AddQueue(temp.X, temp.Y);
        }
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

