using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private Mover mover;

    [SerializeField]
    private InputAction move = new InputAction(
        type: InputActionType.Value,
        expectedControlType: nameof(Vector2));

    void Awake()
    {
        mover = GetComponent<Mover>();
    }

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 velocity = new Vector3(moveDirection.x, moveDirection.y, 0f) * speed;
        mover.SetVelocity(velocity);
    }
}
