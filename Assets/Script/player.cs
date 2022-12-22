using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{

    //[Range(50f, 200f)]
    public float walkSpeed = 100f;

    //[Range(100f, 500f)]
    public float runSpeed = 300f;

    private float mSpeed = 100f;


    //[Range(1000f, 2000f)]
    public float jumpForce = 3000f;

    public LayerMask ground;
    public Transform groundDetector;
    public LayerMask inter;

    Rigidbody rb;

    //Rot
    public Transform play;
    public Transform cam;

    //[Range(50f, 200f)]
    public float xSens = 100f;

    //[Range(50f, 200f)]
    public float ySens = 100f;

    Quaternion center;

    public static bool cursorLock = true;

    public GameObject sp;
    public GameObject panelS;
    public GameObject panelF;

    public Camera camera;


    public void Trans()
    {
        bool groundCheck = Physics.Raycast(groundDetector.position, Vector3.down, 10f, ground);
        bool jump = Input.GetKeyDown(KeyCode.Space) && groundCheck;

        if (jump == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        if (sprint == true && ((zMove > 0 || zMove < 0) || (xMove > 0 || xMove < 0)))
            mSpeed = runSpeed;
        else
            mSpeed = walkSpeed;

        Vector3 dir = new Vector3(xMove, 0, zMove);
        dir.Normalize();

        Vector3 v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
        v.y = rb.velocity.y;
        rb.velocity = v;

    }

    public void Rot()
    {
        float mouseY = Input.GetAxis("Mouse Y") * xSens * Time.deltaTime * 2;
        Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);

        if (Quaternion.Angle(center, yRot) < 90f)
        {
            cam.localRotation = yRot;
        }

        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime * 2;
        Quaternion xRot = play.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        play.localRotation = xRot;


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyUp(KeyCode.Tab))
                cursorLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyUp(KeyCode.Tab))
                cursorLock = true;
        }

    }

    public void span(Vector3 pos)
    {
        if (sp.GetComponent<Spaner>().level == 3)
        {
            panelS.SetActive(true);           
        }
        panelF.SetActive(false);
        transform.position = pos;
        //transform.position = new Vector3(10,10,10);
    }
    // Start is called before the first frame update
    void Start()
    {
        

        sp.GetComponent<Spaner>().GenerateMaze();
        rb = GetComponent<Rigidbody>();

        center = cam.localRotation;
        //span(sp.GetComponent<Spaner>().Star.transform.position);
        //transform.position = sp.GetComponent<Spaner>().Star.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //span(new Vector3(10, 10, 10));
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, inter))
            if (Input.GetMouseButtonDown(0))
            {
                
                hit.transform.GetComponent<interfe>().interact();
                //Debug.Log("fff");
            }
        if (Input.GetMouseButtonDown(0))
            panelS.SetActive(false);




        Trans();

        Rot();
    }
}
