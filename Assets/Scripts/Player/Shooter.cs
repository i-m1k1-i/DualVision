using Unity.Burst.Intrinsics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Aim _aim;

    public void Shoot()
    {
        Bullet bulletInstance = BulletPool.Instance.Get();
        bulletInstance.transform.position = _aim.ShotPoint.position;
        bulletInstance.Direction = _aim.Direction;
    }
}
