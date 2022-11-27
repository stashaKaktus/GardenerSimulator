using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onHeal;
    [SerializeField] private UnityEvent _onDeath;

    public void ModifyHealth(int healthDelta)
    {
        _health += healthDelta;

        if (healthDelta < 0)
        {
            _onDamage?.Invoke();
        }
        else
        {
            _onHeal?.Invoke();
        }

        if (_health <= 0)
        {
            _onDeath?.Invoke();
        }
    }
}
