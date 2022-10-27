using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;

    private PlayerInput _playerInput;
    private Animator _animatorController;
    private float _moveTime = 0f, _moveCooldown = 0.2f;
    private DirectionState _directionState;
    private DirectionState _horizontalDirectionState = DirectionState.Left;
    enum DirectionState
    {
        Right,
        Left,
        Down,
        Up
    }

    private void MoveRight()
    {
        _animatorController.Play("Move Left");
        if (_horizontalDirectionState == DirectionState.Left)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        _directionState = DirectionState.Right;
        _horizontalDirectionState = DirectionState.Right;
        _moveTime = _moveCooldown;
    }

    private void MoveLeft()
    {
        _animatorController.Play("Move Left");
        if (_horizontalDirectionState == DirectionState.Right)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        _directionState = DirectionState.Left;
        _horizontalDirectionState = DirectionState.Left;
        _moveTime = _moveCooldown;
    }

    private void MoveUp()
    {
        _animatorController.Play("Move Up");
        _directionState = DirectionState.Up;
        _moveTime = _moveCooldown;
    }

    private void MoveDown()
    {
        _animatorController.Play("Move Down");
        _directionState = DirectionState.Down;
        _moveTime = _moveCooldown;
    }

    private void Idle()
    {
        _animatorController.Play("Idle");
    }

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

        //DirectionState currentDirection;
        _moveTime -= Time.deltaTime;
        if (_moveTime <= 0)
            Idle();

        if (moveDirection.y > 0)
            MoveUp();
        else if (moveDirection.y < 0)
            MoveDown();
        else if (moveDirection.x < 0)
            MoveLeft();
        else if (moveDirection.x > 0)
            MoveRight();
    }

    //private bool IsDirectionStateChanged(Vector2 direction)
    //{
    //    if (direction == Vector2.zero)
    //        Idle();
    //    else if (direction.y > 0)
    //        MoveUp();
    //    else if (direction.y < 0)
    //        MoveDown();
    //    else if (direction.x < 0)
    //        MoveLeft();
    //    else if (direction.x > 0)
    //        return false;
    //}
}
