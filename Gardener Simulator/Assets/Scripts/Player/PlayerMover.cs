using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private PlayerController _playerController;

    private Rigidbody2D _rigidbody;
    private Animator _animatorController;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveDirection)
    {
        _rigidbody.velocity = new Vector2(_moveSpeed * moveDirection.x, _moveSpeed * moveDirection.y);

        if (moveDirection == Vector2.zero)
            Idle();
        else if (moveDirection.y == 1)
        {
            Move(PlayerController.UP);
        }
        else if (moveDirection.y == -1)
        {
            Move(PlayerController.DOWN);
        }
        else if (moveDirection.x == 1)
        {
            Move(PlayerController.RIGHT);
        }
        else if (moveDirection.x == -1)
        {
            Move(PlayerController.LEFT);
        }
    }

    public void SetMoveSpeed(float speed)
    {
        _moveSpeed = speed;
    }

    private void Move(string direction)
    {
        if (direction == _playerController.DirectionState)
            return;

        _animatorController.Play($"Move {direction}");
        _playerController.DirectionState = direction;
    }

    private void Idle()
    {
        _animatorController.Play($"Idle {_playerController.DirectionState}");
    }
}