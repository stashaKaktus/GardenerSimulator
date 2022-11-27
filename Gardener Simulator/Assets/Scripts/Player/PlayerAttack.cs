using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _attackRadius = 1f;
    [SerializeField] private int _damage;

    private Collider2D[] _interactionResult = new Collider2D[5];

    private int Check()
    {
        return Physics2D.OverlapCircleNonAlloc(transform.position, _attackRadius, _interactionResult);
    }

    // рисует гизмо
    /*private void OnDrawGizmosSelected()
    {
        Handles.DrawSolidDisc(transform.position, new Vector3(0, 0, 1), _attackRadius);
    }*/

    // тоже рисует
/*    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, _attackRadius);
    }*/

    public void Attack()
    {
        int size = Check();

        for (int i = 0; i < size; i++)
        {
            if (_interactionResult[i].TryGetComponent<HealthComponent>(out HealthComponent hc))
            {
                hc.ModifyHealth(-_damage);
            }
        }
    }
}
