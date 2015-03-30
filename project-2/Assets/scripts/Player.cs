using UnityEngine;
using System.Collections;

public class Player {

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


}
