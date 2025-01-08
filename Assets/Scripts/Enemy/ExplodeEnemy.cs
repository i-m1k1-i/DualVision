using UnityEngine;

public class ExplodeEnemy : Enemy
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _direction = (_player.transform.position - transform.position).normalized;

        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}