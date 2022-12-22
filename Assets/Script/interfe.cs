using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { idle = 0, walk, open, kick };

public abstract class interfe : MonoBehaviour
{
    public abstract void interact();
    //public abstract Vector3 getPoint(Vector3 position);

    public abstract States getAction();


}
