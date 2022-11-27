using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactionLayer;

    private Collider2D[] _interactionResult = new Collider2D[1];

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, _interactionRadius);
    }

    public void Interact()
    {
        int size = Physics2D.OverlapCircleNonAlloc(transform.position,
            _interactionRadius, _interactionResult, _interactionLayer);

        for (int i = 0; i < size; ++i)
        {
            if (_interactionResult[i].TryGetComponent<InteractingObject>(out InteractingObject io))
            {
                io.Interact();
            }
        }
    }
}
