using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Coroutine _current;
    private GameObject _target;

    private void Start()
    {
        StartState(Patrolling());
    }

    public void OnPlayerInVision(GameObject player)
    {
        _target = player;
        StartState(AgroToPlayer());
    }

    private IEnumerator AgroToPlayer()
    {
        _animator.Play("Idle");
        yield return new WaitForSeconds(1f);
        StartState(StalkingPlayer());
    }


    private IEnumerator StalkingPlayer()
    {
        yield return null;
    }

    private IEnumerator Patrolling()
    {
        yield return null;
    }

    private void StartState(IEnumerator coroutine)
    {
        if(_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(coroutine);
    }
}
