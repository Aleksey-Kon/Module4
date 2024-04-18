using UnityEngine;
public class attack : MonoBehaviour
{
    private bool CanAttack => _attackTime <= 0;

    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _damageMask;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    private Collider[] _hits = new Collider[3];
    private float _attackTime;

    private void Start() => ResetAttackTimer();

    void Update()
    {
        if (!CanAttack)
        {
            _attackTime -= Time.deltaTime;
        }
        if (gameObject.tag == "Player" && Input.GetMouseButtonDown(0) && CanAttack)
        {
         
                SetAttack();
         
        }

    }
    public void SetAttack()
    {
        _animator.SetTrigger("Attack");
        ResetAttackTimer();
        AttackNearEnemies();
    }
    private void AttackNearEnemies()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, _radius, _hits, _damageMask);

        for (int i = 0; i < count; i++)
        {
            if (_hits[i].TryGetComponent<IDamageble>(out var damagble))
            {
                damagble.TakeDamage?.Invoke(this, _damage);
            }
        }
    }
    private void ResetAttackTimer() => _attackTime = _attackCooldown;
}