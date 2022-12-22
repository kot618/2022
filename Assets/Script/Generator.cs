using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator 
{
    int Width = 10;
    int Height = 10;

    // public GameObject S;

    public Maze Gener(int Width, int Hight)
    {
        this.Width = Width;
        this.Height = Hight;

        MazeCell[,] cell = new MazeCell[Width, Hight];

        for (int x = 0; x < cell.GetLength(0); x++)
        {
            for (int y = 0; y < cell.GetLength(1); y++)
            {
                cell[x, y] = new MazeCell { X = x, Y = y };
                cell[x, y].dis = -1;
            }
        }

        Maze maze = new Maze();
        //removeWalls(cell);

        //int vis = 0;

        int i = Random.Range(0, Width);
        int j = Random.Range(0, Height);
        //MazeCell n = cus(cell, cell[i, j]);

        Laber(cell, cell[i, j]);

        cell[i, j].dis = 0;
        //правильный перебор элементов
        Prover(cell[i, j], cell);



        maze.cell = cell;
        return maze;

    }

    private MazeCell cus(MazeCell[,] maze, MazeCell fo)
    {

        List<MazeCell> unvi = new List<MazeCell>();

        int i = fo.X;
        int j = fo.Y;

        //if (maze[i, j].Visited == false) 

        if (i > 0)
        {
            //if(!maze[i - 1, j].Visited)
            unvi.Add(maze[i - 1, j]);
        }
        if (j > 0)
        {
            //if (!maze[i, j - 1].Visited)
            unvi.Add(maze[i, j - 1]);
        }
        if (i < Width - 1)
        {
            //if (!maze[i + 1, j].Visited)
            unvi.Add(maze[i + 1, j]);
        }
        if (j < Height - 1)
        {
            //if (!maze[i, j + 1].Visited)
            unvi.Add(maze[i, j + 1]);
        }
        MazeCell chosen = unvi[UnityEngine.Random.Range(0, unvi.Count)];

        return chosen;
    }


    private void Laber(MazeCell[,] maze, MazeCell n)
    {
        int count = Width * Height;

        MazeCell curr = n;
        curr.dis = 0;
        count--;


        while (count > 0)
        {

            int i = curr.X;
            int j = curr.Y;

            MazeCell choosen = cus(maze, curr);

            if (choosen.Visited == false)
            {
                count--;
                RemoveWall(choosen, curr);

                //RemoveWall(maze[i, j], chosen);
                //vis++;
                //Laber(maze, chosen, vis);

            }

            maze[i, j].Visited = true;
            curr = choosen;

        }

    }

    private void removeWalls(MazeCell[,] maze)
    {
        //GameObject D = S.GetComponent<Spaner>().S;

        //MazeCell current = maze[Random.Range(0, Width), Random.Range(0, Height)];
        MazeCell current = maze[0, 0];
        current.Visited = true;
        //current.dis = 0;
        //D.transform.position=new Vector3(current.X,0,current.Y);



        Stack<MazeCell> stack = new Stack<MazeCell>();
        do
        {
            List<MazeCell> unvi = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited)
            {

                unvi.Add(maze[x - 1, y]);

            }
            if (y > 0 && !maze[x, y - 1].Visited)
            {

                unvi.Add(maze[x, y - 1]);
            }
            if (x < Width - 1 && !maze[x + 1, y].Visited)
            {

                unvi.Add(maze[x + 1, y]);
            }
            if (y < Height - 1 && !maze[x, y + 1].Visited)
            {

                unvi.Add(maze[x, y + 1]);
            }

            if (unvi.Count > 0)
            {
                MazeCell chosen = unvi[UnityEngine.Random.Range(0, unvi.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);

                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);

    }

    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
            {
                b.FS = false;
                a.BS = false;
                b.Dver2 = true;
            }
            else
            {
                a.FS = false;
                b.BS = false;
                a.Dver2 = true;
            }
        }
        else
        {
            if (a.X > b.X)
            {
                a.LS = false;
                b.RS = false;
                b.Dver1 = true;
            }
            else
            {
                b.LS = false;
                a.RS = false;
                a.Dver1 = true;
            }
        }
    }


    private void Prover(MazeCell current, MazeCell[,] maze)
    {
        int a = current.X;
        int b = current.Y;

        if (maze[a, b].LS == false /*&& a > 0*/)
            if (maze[a - 1, b].dis < 0)
            {
                maze[a - 1, b].dis = current.dis + 1;
                Prover(maze[a - 1, b], maze);
            }

        if (maze[a, b].RS == false /*&& a < Width - 1*/)
            if (maze[a + 1, b].dis < 0)
            {
                maze[a + 1, b].dis = current.dis + 1;
                Prover(maze[a + 1, b], maze);

            }
        if (maze[a, b].BS == false /*&& b > 0*/)
            if (maze[a, b - 1].dis < 0)
            {
                maze[a, b - 1].dis = current.dis + 1;
                Prover(maze[a, b - 1], maze);
            }

        if (maze[a, b].FS == false /*&& b < Width - 1*/)
            if (maze[a, b + 1].dis < 0)
            {
                maze[a, b + 1].dis = current.dis + 1;
                Prover(maze[a, b + 1], maze);
            }


    }
}
