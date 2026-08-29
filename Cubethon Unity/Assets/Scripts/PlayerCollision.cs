using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovementScript;

    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            playerMovementScript.enabled = false;
        }
    }
}
