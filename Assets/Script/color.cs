using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    private Renderer ren;
    public Material material1;
    public Material material2;
    public Material material3;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //ren = GetComponent<Renderer>();
        //ren.material = material1;
    }

    public void level(int lev)
    {
       
        ren = GetComponent<Renderer>();
        if(lev == 0)
        ren.material = material1;
        if (lev == 1)
            ren.material = material2;
        if (lev>=2)
            ren.material = material3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
