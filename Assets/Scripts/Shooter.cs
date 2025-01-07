using Unity.Burst.Intrinsics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Aim _aim;

    public void Shoot()
    {
        Bullet bulletInstance = Instantiate(_bulletPrefab);
        bulletInstance.transform.position = _aim.ShotPoint.position;
        bulletInstance.Direction = _aim.Direction;
    }
}
