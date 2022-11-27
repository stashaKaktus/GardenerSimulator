using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _character;
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private bool _loop;

    private int _currentPoint = 0;
    private string _directionState = DOWN;
    private Animator _animatorController;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";

    private Vector3 _direction;

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform target = _targetPoints[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        var direction = (target.position - transform.position).normalized;

        Move(direction);
        _direction = direction;

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _targetPoints.Length)
                _currentPoint = 0;
        }
    }

    public void Move(Vector3 moveDirection)
    {
        if (moveDirection == Vector3.zero)
            Idle();

        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            if (moveDirection.x > 0)
            {
                Move(RIGHT);
            }
            else if (moveDirection.x < 0)
            {
                Move(LEFT);
            }
        }
        else
        {
            if (moveDirection.y >= 0)
            {
                Move(UP);
            }
            else if (moveDirection.y < 0)
            {
                Move(DOWN);
            }
        }
    }

    private void Move(string direction)
    {
/*        if (direction == _directionState)
            return;*/

        Debug.Log($"{_direction}  ==  MOVE {direction}");
        _animatorController.Play($"Move {direction}");
        _directionState = direction;
    }

    private void Idle()
    {
        Debug.Log($"{_direction}  ==  IDLE {_directionState}");
        _animatorController.Play($"Idle {_directionState}");
    }
}
