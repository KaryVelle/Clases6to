using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private InputAction moveAction;
    private InputAction lookAction;

    void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
    }

    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
    }

    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        LookInput = lookAction.ReadValue<Vector2>();
    }
}