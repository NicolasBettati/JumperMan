using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool grounded = false;
    public Collider col;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger: " + other);
        if(other.tag == "Terrain")
        {
            grounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger lost: " + other);
        if(other.tag == "Terrain")
        {
            grounded = false;
        }
    }
}
