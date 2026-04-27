using System;
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
        mouseX = Input.GetAxis("Mouse X");
        pivot.transform.Rotate(new Vector3(0f, 1f, 0f)*mouseX*sensitivityX*Time.deltaTime);
        mouseY = Input.GetAxis("Mouse Y");
        pivot.transform.Rotate(new Vector3(-Math.Clamp(mouseY*sensitivityY*Time.deltaTime,-13f,13f), 0f, 0f));
    }
}
