using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.VersionControl.Asset;

public class Dver : interfe
{
    Animator an;
    bool op = false;
    int t = 0;
    //public Transform point1;
    //public Transform point2;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    public override States getAction()
    {
        return States.open;
    }

    public override void interact()
    {
        if (op == false)
        {
            an.SetBool("D", true);
            op = true;
            t = 5;
        }
        else
        {
            an.SetBool("D", false);
            op = false;
        }

        //Debug.Log("fff");
    }

    //public override Vector3 getPoint(Vector3 position)
    //{
    //    var dist1 = Vector3.Distance(position, point1.position);
    //    var dist2 = Vector3.Distance(position, point2.position);

    //    if (dist1 < dist2)
    //    {
    //        return point1.position;
    //    }
    //    else
    //    {
    //        return point2.position;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
