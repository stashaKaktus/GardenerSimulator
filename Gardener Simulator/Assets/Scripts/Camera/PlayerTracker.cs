using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] private float _smoothSpeed = 0.01f;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
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
        Vector3 offset = _playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y, -10) + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed);
    }
}
