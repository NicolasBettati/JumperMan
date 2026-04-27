using System;
using Unity.Mathematics;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private int speedMult = 1;
    [SerializeField]
    private int jumpMult = 1;
    public Transform pivot;
    Rigidbody rb;
    groundCheck gc;
    float mouseX = 0;
    public float sensitivityX= 1;
    public float sensitivityY = 1;
    float mouseY = 0;

    private float pitch = 0f;
    private float roll = 0f;
    public float max = 90f;
    public float min = -90f;

    void Start(){
        rb = GetComponent<Rigidbody>();
        gc = GetComponentInChildren<groundCheck>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
   
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gc.grounded){
            Debug.Log("Jump Pressed");
            rb.AddForce(new Vector3(0f, 5f * jumpMult, 0f));
        }

        //! GET THE AXIS
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        //! PROCESS THE AXIS
        pitch -= -1*mouseY;
        pitch = Math.Clamp(pitch, min, max);
        roll -= -1*mouseX;
        //! SET THE ROTATION
        pivot.localRotation = Quaternion.Euler(pitch,roll,0f);
    }
}
//skibid toilet