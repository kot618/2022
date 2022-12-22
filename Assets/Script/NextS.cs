using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NextS : MonoBehaviour
{
    private Renderer ren;
    //public Material SelectM;
    //public GameObject panel;
    public GameObject span;
    public GameObject panelF;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();

        //panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Transform objectHit = hit.transform;
        

        if (other.transform.CompareTag("Player") == true)
        {
            //ren.material = SelectM;
            //panel.SetActive(true);
           if( span.GetComponent<Spaner>().level>-1)
                span.GetComponent<Spaner>().GenerateMaze();
            else
            {
                panelF.SetActive(true);
                //Debug.Log("game over");
            }
            
            //Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
