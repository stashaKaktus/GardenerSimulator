using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private string _directionState = DOWN;
    private Animator _animatorController;

    private PlayerMover _playerMover;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";
    public string DirectionState { get { return _directionState; } set { _directionState = value; } }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _animatorController = GetComponent<Animator>();

        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _playerMover.Move(moveDirection);
    }
}