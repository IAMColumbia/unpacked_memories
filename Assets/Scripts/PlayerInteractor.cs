using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    
    [Tooltip("The input action that interacts with whatever the player is looking at.")]
    [SerializeField] private InputActionReference _interactAction;

    [Tooltip("How far away, in meters, the player can reach to interact.")]
    [SerializeField] private float _reachDistance = 2f;

    private void OnEnable()
    {
        _interactAction.action.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        _interactAction.action.performed -= OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        Transform cameraTransform = Camera.main.transform;
        bool hitSomething = Physics.Raycast(
            cameraTransform.position,
            cameraTransform.forward,
            out RaycastHit hit,
            _reachDistance
        );

        if (!hitSomething)
        {
            return;
        }

        Debug.Log("Hit object: " + hit.collider.name);

        Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
