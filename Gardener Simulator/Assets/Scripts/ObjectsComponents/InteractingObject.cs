using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractingObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] CanvasGroup _tooltip;
    [SerializeField] private UnityEvent _action;

    public void Interact()
    {
        _action?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tooltip.alpha = 1;
        _spriteRenderer.color = new Color(0.9f,0.9f,0.9f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _tooltip.alpha = 0;
        _spriteRenderer.color = Color.white;
    }
}
