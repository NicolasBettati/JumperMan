using System;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private int speedMult = 1;
    [SerializeField]
    private int jumpMult = 1;
    Rigidbody rb;
    groundCheck gc;

    void Start(){
        rb = GetComponent<Rigidbody>();
        gc = GetComponentInChildren<groundCheck>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && gc.grounded){
            Debug.Log("Jump Pressed");
            rb.AddForce(new Vector3(0f, 5f * jumpMult, 0f));
        }
    }
}
