using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast the player walks, in meters per second.")]
    [SerializeField] private float _walkSpeed = 3f;
    
    [Tooltip("The input action that moves the player.")]
    [SerializeField] private InputActionReference _moveAction;

    
    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = _moveAction.action.ReadValue<Vector2>();
        Debug.Log($"X={moveInput.x}, Y={moveInput.y}");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * moveInput.y + right * moveInput.x;
        characterController.Move(direction * _walkSpeed * Time.deltaTime);
    }
}
