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
    private DirectionState _directionState = DirectionState.Down;
    private DirectionState _horizontalDirectionState = DirectionState.Left;
    enum DirectionState
    {
        Right,
        Left,
        Down,
        Up
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

        //_moveTime -= Time.deltaTime;
        /*if (_moveTime <= 0)
            Idle();*/
        if (moveDirection == Vector2.zero)
        {
            Idle();
            return;
        }

        if (moveDirection.y == 1)
            MoveUp();
        else if (moveDirection.y == -1)
            MoveDown();
        else if (moveDirection.x == 1)
            MoveRight();
        else if (moveDirection.x == -1)
            MoveLeft();
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
        if(_directionState == DirectionState.Down)
            _animatorController.Play("Idle Down");
        else if(_directionState == DirectionState.Up)
            _animatorController.Play("Idle Up");
        else if(_directionState == DirectionState.Left || _directionState == DirectionState.Right)
            _animatorController.Play("Idle Left");
    }
}
