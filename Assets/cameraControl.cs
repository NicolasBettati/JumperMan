using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform objective;
    public float followSpeed;

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.position, objective.transform.position, followSpeed);
    }
}
