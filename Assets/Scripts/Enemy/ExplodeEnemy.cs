using System.Collections;
using UnityEngine;

public class ExplodeEnemy : Enemy
{
    [Header("Components")]
    [SerializeField] private Moveable _moveable;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _explosion;

    [Header("Explosion settings")]
    [SerializeField] private float _explodeDistance;
    [SerializeField] private float _damageDistance;
    [SerializeField] private float _explodeDelay;
    [SerializeField] private float _damage;

    private Vector3 _direction;
    private bool _startExploding;

    private void Update()
    {
        if (_startExploding)
            return;

        _moveable.Move();

        float distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if (distanceToPlayer <= _explodeDistance)
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        _startExploding = true;
        _animator.SetBool("Explode", true);

        yield return new WaitForSeconds(_explodeDelay);

        Instantiate(_explosion, transform.position, Quaternion.identity);

        float distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if (distanceToPlayer <= _damageDistance)
        {
            Health playerHealth = Player.Instance.GetComponent<Health>();
            playerHealth.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}