using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction moveAction;

    private Vector2 movementInput;
    private Rigidbody rigidBody;

    public float forwardSpeed = 5;
    public float movementSpeed = 5;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementInput = moveAction.ReadValue<Vector2>();
        float xSpeed = movementInput.x*movementSpeed;

        rigidBody.linearVelocity = new Vector3(xSpeed, rigidBody.linearVelocity.y, forwardSpeed);
    }
}
