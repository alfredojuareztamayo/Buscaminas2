using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a tile in a game.
/// </summary>
public class Tile
{
    /// <summary>
    /// Gets or sets a value indicating whether the tile is visible.
    /// </summary>
    public bool IsVisible { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether a flag is placed on the tile.
    /// </summary>
    public bool FlagOn { get; private set; }

    /// <summary>
    /// Gets the number of bombs near the tile.
    /// </summary>
    public int BombsNear { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the tile contains a bomb.
    /// </summary>
    public bool BomboN { get; private set; }

    /// <summary>
    /// Gets the bomb counter value of the tile.
    /// </summary>
    public int BombCounter { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the tile contains a bomb.
    /// </summary>
    public bool InQueue { get; private set; }
    /// <summary>
    /// Initializes a new instance of the Tile class.
    /// </summary>

    public int X { get; private set; }
    public int Y { get; private set; }
    public Tile()
    {
        // TODO: Add any necessary initialization logic.
    }

    /// <summary>
    /// Initializes a new instance of the Tile class with the specified bomb status.
    /// </summary>
    /// <param name="isBomb">A value indicating whether the tile contains a bomb.</param>
    public Tile(bool isBomb)
    {
        BomboN = isBomb;
    }

    /// <summary>
    /// Increments the number of bombs near the tile by one.
    /// </summary>
    public void AddBombsNear()
    {
        BombsNear++;
    }

    /// <summary>
    /// Makes the tile visible.
    /// </summary>
    public void Visible()
    {
        IsVisible = true;
    }
    /// <summary>
    /// Makes the tile in de queue.
    /// </summary>
    public void InQueueNum()
    {
        InQueue = true;
    }
    public void AddX(int num)
    {
        X = num;
    }
    public void Addy(int num)
    {
        Y = num;
    }
}

