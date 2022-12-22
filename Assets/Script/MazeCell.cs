using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{

    public int X;
    public int Y;

    public bool LS = true;
    public bool RS = true;
    public bool BS = true;
    public bool FS = true;
    public bool Dver1 = false;
    public bool Dver2 = false;

    public int dis;

    public bool Visited = false;
    
}
