using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference moveAction;
    public float WalkSpeed = 3f;
    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Debug.Log($"X={moveInput.x}, Y={moveInput.y}");
        Debug.Log(moveAction.action.name);

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * moveInput.y + right * moveInput.x;
        characterController.Move(direction * WalkSpeed * Time.deltaTime);
    }
}
