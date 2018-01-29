using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private float time;

    public Player(string name)
    {
        this.name = name;
        time = 0;
    }
   
    public string getName()
    {
        return name;
    }

    public void setTime(float time)
    {
        this.time = time;
    }
    
    public float getTime()
    {
        return time;
    }
}
