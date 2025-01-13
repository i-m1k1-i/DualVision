using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Aim _aim;

    public void Shoot()
    {
        SoundEffectsManager.Instance.PlayShotSound(true);
        Bullet bulletInstance = BulletPool.Instance.Get();
        bulletInstance.transform.position = _aim.ShotPoint.position;
        bulletInstance.Direction = _aim.Direction;
    }
}
