using UnityEngine;

public class GroundFollower : Moveable
{
    [SerializeField] private float _speed;

    public override void Move()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        transform.Translate(_speed * Time.deltaTime * direction);        
    }
}
