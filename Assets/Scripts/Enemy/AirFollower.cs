using UnityEngine;

class AirFollower : Moveable
{
    [SerializeField] private float _flyHeight;
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, _flyHeight, transform.position.z);
    }

    public override void Move()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        direction.y = 0;
        transform.Translate(_speed * Time.deltaTime * direction);
    }
}