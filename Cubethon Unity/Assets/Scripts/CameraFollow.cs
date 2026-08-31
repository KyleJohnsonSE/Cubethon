using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = target.position + offset;
    }
}
