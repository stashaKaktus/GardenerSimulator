using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private float _offset;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
    }
}
