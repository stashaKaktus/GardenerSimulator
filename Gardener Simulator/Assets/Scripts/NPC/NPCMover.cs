using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

enum MovementState
{
    Move,
    Idle
}

enum DirectionState
{
    Up,
    Down,
    Left,
    Right
}


[RequireComponent(typeof(Animator))]
public class NPCMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _character;
    [SerializeField] private Transform[] _targetPoints;

    private int _currentPoint = 0;
    private MovementState _movementState = MovementState.Idle;
    private DirectionState _directionState = DirectionState.Down;
    private Animator _animatorController;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform target = _targetPoints[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        var direction = (target.position - transform.position).normalized;
        SetDirectionState(direction);

        Debug.Log(direction);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _targetPoints.Length)
                _currentPoint = 0;
        }
    }

    private void SetDirectionState(Vector3 moveDirection)
    {
        if (moveDirection == Vector3.zero)
        {
            Idle();
            return;
        }

        if (moveDirection.y > 0)
            Move(DirectionState.Up);
        else if (moveDirection.y < 0)
            Move(DirectionState.Down);
        else if (moveDirection.x > 0)
            Move(DirectionState.Right);
        else if (moveDirection.x < 0)
            Move(DirectionState.Left);
    }

    private void Move(DirectionState direction)
    {
        if (direction == _directionState)
            return;

        switch (direction)
        {
            case DirectionState.Up:
                _animatorController.Play($"Move {UP}");
                break;
            case DirectionState.Down:
                _animatorController.Play($"Move {DOWN}");
                break;
            case DirectionState.Left:
                _animatorController.Play($"Move {LEFT}");
                break;
            case DirectionState.Right:
                _animatorController.Play($"Move {RIGHT}");
                break;
        }

        _directionState = direction;
        _movementState = MovementState.Move;
    }

    private void Idle()
    {
        if (_movementState == MovementState.Idle)
            return;

        switch (_directionState)
        {
            case DirectionState.Up:
                _animatorController.Play($"Idle {UP}");
                break;
            case DirectionState.Down:
                _animatorController.Play($"Idle {DOWN}");
                break;
            case DirectionState.Left:
                _animatorController.Play($"Idle {LEFT}");
                break;
            case DirectionState.Right:
                _animatorController.Play($"Idle {RIGHT}");
                break;
        }

        _animatorController.Play($"Idle {_directionState}");
        _movementState = MovementState.Idle;
    }




    // Через direction и проверку дистанции
    /*    Transform target = _targetPoints[_currentPoint];

        var direction = (target.position - transform.position).normalized;
        var dir2 = Vector3.Normalize(target.position - transform.position);
        Debug.Log($"{target.position - transform.position} = {direction} , {dir2}");
            transform.Translate(direction.x* _moveSpeed * Time.deltaTime, direction.y* _moveSpeed * Time.deltaTime, 0);

            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                _currentPoint++;
                Debug.Log("NEXT ============");
                if (_currentPoint >= _targetPoints.Length)
                    _currentPoint = 0;
            }*/


    // Через MoveTowards
    /*    Transform target = _targetPoints[_currentPoint];

        var direction = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed* Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;
                if (_currentPoint >= _targetPoints.Length)
                    _currentPoint = 0;
            }*/
}
