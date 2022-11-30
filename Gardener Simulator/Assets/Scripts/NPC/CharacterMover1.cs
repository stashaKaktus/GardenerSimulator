using UnityEngine;

public class CharacterMover1 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _character;

    private string _directionState = DOWN;
    private Animator _animatorController;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string RIGHT = "Right";
    public const string LEFT = "Left";

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }

    public void Move(Vector3 moveDirection)
    {
        Debug.Log(moveDirection);

        if (moveDirection == Vector3.zero)
        {
            Idle();
            return;
        }

        _character.Translate(moveDirection * _moveSpeed * Time.deltaTime);

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
            if (moveDirection.y > 0)
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
