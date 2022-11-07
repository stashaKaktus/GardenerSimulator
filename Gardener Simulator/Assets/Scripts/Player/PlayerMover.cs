using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
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
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _rigidbody.velocity = new Vector2(_moveSpeed * moveDirection.x, _moveSpeed * moveDirection.y);
        //transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);

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