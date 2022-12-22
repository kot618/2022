using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaner : MonoBehaviour
{
    //public Camera cam;
   public GameObject play;
    public GameObject mazeHandler;

    public Cell CellPrefab;
    public Vector2 CellSize = new Vector2(1, 1);

    public int Width = 10;
    public int Height = 10;

    public int level = 3;
   //Cell Star = new Cell();
    //public GameObject S;

    public void GenerateMaze()
    {
        Debug.Log(level);

        foreach (Transform child in mazeHandler.transform)
            GameObject.Destroy(child.gameObject);

        Cell Start=new Cell();
        Cell Finish = new Cell();
        int f = 0;

        Generator generator = new Generator();
        Maze maze = generator.Gener(Width+3-level, Height + 3 - level);

        for (int x = 0; x < maze.cell.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cell.GetLength(1); z++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, 0, z * CellSize.y), Quaternion.identity);

                for (int i = 0; i < 8; i++)
                    c.col[i].level(level);

                if (maze.cell[x, z].BS == false)
                    Destroy(c.BS);
                if (maze.cell[x, z].FS == false)
                    Destroy(c.FS);
                if (maze.cell[x, z].RS == false)
                    Destroy(c.RS);
                if (maze.cell[x, z].LS == false)
                    Destroy(c.LS);
                if (maze.cell[x, z].Dver1 != true)
                    Destroy(c.dver1);
                if (maze.cell[x, z].Dver2 != true)
                    Destroy(c.dver2);

                c.transform.parent = mazeHandler.transform;
               
                if(maze.cell[x, z].dis > f)
                {
                    f=maze.cell[x, z].dis;
                    Finish = c;
                }

                //c.distance.text = maze.cell[x, z].dis.ToString();
                if (maze.cell[x, z].dis == 0) Start = c;
            }
            Debug.Log(x);
        }
        Destroy(Finish.pol);
        Debug.Log(Start.transform.position);
        //play.transform.position=new Vector3(Start.transform.position.x, Start.transform.position.y+1, Start.transform.position.z);
        //cam.transform.position = new Vector3(Width * CellSize.x / 2, Mathf.Max(Width, Height) * 7, Width * CellSize.x / 2);
        play.GetComponent<player>().span(new Vector3(Start.transform.position.x, Start.transform.position.y + 2, Start.transform.position.z));
        //Debug.Log(play.transform.position);
        if (level>0)
            level--;
        
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
