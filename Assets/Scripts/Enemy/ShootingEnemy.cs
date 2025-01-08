using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private Moveable _moveable;

    [SerializeField] private float _shootDistance;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _shootDamage;

    private float _shootTime;
    private bool _stop;

    private void Update()
    {
        if (_stop == false)
            _moveable.Move();

        float distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if (distanceToPlayer <= _shootDistance)
        {
            _stop = true;
        }
        else
        {
            _stop = false;
        }

        if (_shootTime >= _shootDelay && _stop)
        {
            Shoot();
        }
        else
        {
            _shootTime += Time.deltaTime;
        }
    }

    private void Shoot()
    {
       Vector3 directionToPlayer = (Player.Instance.transform.position - transform.position).normalized;
        EnemyBullet bullet = EnemyBulletPool.Instance.Get();
        bullet.transform.position = transform.position;
        bullet.Direction = directionToPlayer;

        _shootTime = 0;
    }
}
