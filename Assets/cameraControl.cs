using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform objective;
    public float followSpeed;
    public Transform player;

    void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.position, objective.transform.position, followSpeed*Time.deltaTime);
        transform.LookAt(player);

    }
}
