using UnityEngine;
using System.Collections;
using System;

public class Player: IComparable{

    public string Name { get; set; }
    public float Time { get; set; }

    public Player()
    {
        Name = "";
        Time = 0.0f;
    }

    public Player(string name, float time)
    {
        this.Name = name;
        this.Time = time;
    }

    /// <summary>
    /// Compares this player's time to another's. The greater one is the least time.
    /// </summary>
    /// <param name="otherPlayer"></param>
    /// <returns></returns>
    public int CompareTo(System.Object otherPlayer)
    {
        if (otherPlayer is Player)
        {
            Player temp = (Player)otherPlayer;
            if (this.Time > temp.Time) return -1;
            if (this.Time == temp.Time) return 0;
            return 1;
        }
        else
            return -1;

    }


}
