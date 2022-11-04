using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;

    private PlayerInput _playerInput;
    private string _directionState = DOWN;
    private Animator _animatorController;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _animatorController = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);

        if (moveDirection == Vector2.zero)
            Idle();
        else if (moveDirection.y == 1)
            Move(UP);
        else if (moveDirection.y == -1)
            Move(DOWN);
        else if (moveDirection.x == 1)
            Move(RIGHT);
        else if (moveDirection.x == -1)
            Move(LEFT);
    }

    private void Move(string direction)
    {
        if (direction == _directionState)
            return;

        _animatorController.Play($"Move {direction}");
        _directionState = direction;
    }

    private void Idle()
    {
        _animatorController.Play($"Idle {_directionState}");
    }
}