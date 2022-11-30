using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _treshold = 1f;
    [SerializeField] private bool _loop;
    [SerializeField] private float _loopTime = 0f;

    private int _currentPoint = 0;
    private CharacterMover1 _mover;
    private float _elapsedTime = 0f;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover1>();
    }

    private void Update()
    {
        //Transform target = _targetPoints[_currentPoint];

        if ((_targetPoints[_currentPoint].position - transform.position).magnitude < _treshold)
        {
            if (_currentPoint + 1 == _targetPoints.Length)
            {
                if (_loop)
                {
                    if (_elapsedTime >= _loopTime)
                    {
                        _currentPoint = 0;
                        _elapsedTime = 0f;
                    }
                    else
                    {
                        _elapsedTime += Time.deltaTime;
                        _mover.Move(Vector3.zero);
                        return;
                    }
                }
                else
                {
                    _mover.Move(Vector3.zero);
                    enabled = false;
                }
            }
            else
                _currentPoint++;
        }

        Vector3 direction = (_targetPoints[_currentPoint].position - transform.position).normalized;

        _mover.Move(direction);
    }
}
