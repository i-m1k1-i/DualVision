using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = Direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Static")
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.TryGetComponent<Health>(out Health health) == false)
        {
            return;
        }

        health.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
