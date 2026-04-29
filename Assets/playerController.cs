using System;
using Unity.Mathematics;
using UnityEngine;

public class playerController : MonoBehaviour
{
[SerializeField] private int speedMult = 1;
    [SerializeField] private float jumpMult = 1;
    public int moveMult = 1;
    public Transform pivot;
    public Transform cameraTransform;
    public int maxSpeed;
    public float rotationSpeed = 10f;

    Rigidbody rb;
    groundCheck gc;

    float mouseX = 0;
    float mouseY = 0;
    public float sensitivityX = 1;
    public float sensitivityY = 1;

    private float pitch = 0f;
    private float yaw = 0f;
    public float max = 90f;
    public float min = -90f;

    public float frenado = 0.95f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gc = GetComponentInChildren<groundCheck>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = pivot.eulerAngles.y;
    }
   
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        mouseY = Input.GetAxis("Mouse Y") * -sensitivityY;

        yaw += mouseX;
        pitch += mouseY;
        pitch = Mathf.Clamp(pitch, min, max);

        pivot.rotation = Quaternion.Euler(pitch, yaw, 0f);

        if (Input.GetButtonDown("Jump") && gc.grounded)
        {
            rb.AddForce(Vector3.up * 5f * jumpMult, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight   = cameraTransform.right;
        camForward.y = 0f;
        camRight.y   = 0f;
        camForward.Normalize();
        camRight.Normalize();
        Vector3 moveDir = (camForward * verti + camRight * horiz).normalized;

        if (moveDir.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.fixedDeltaTime * rotationSpeed
            );
            rb.AddForce(moveDir * moveMult, ForceMode.Force);
        }

        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 clamped = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(clamped.x, rb.linearVelocity.y, clamped.z);
        }
        bool movingH = Input.GetButton("Horizontal");
        bool movingV = Input.GetButton("Vertical");

        if (!movingH && !movingV && gc.grounded)
        {
            Vector3 vel = rb.linearVelocity;
            rb.linearVelocity = new Vector3(vel.x * frenado, vel.y, vel.z * frenado);
        }
    }
}
//skibid toilet