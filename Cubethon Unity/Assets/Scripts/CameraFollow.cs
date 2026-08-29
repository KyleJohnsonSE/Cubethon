using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform focus;

    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        offset = transform.position - focus.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = focus.position + offset;
    }
}
