using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> _onCameIntoView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent<Player>(out Player player))
        {
            _onCameIntoView?.Invoke(player.gameObject);
        }
    }
}
