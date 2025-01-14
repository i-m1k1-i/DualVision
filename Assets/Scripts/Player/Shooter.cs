using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Aim _aim;
    [SerializeField] private PlayerUI _playerUI;

    public void Shoot()
    {
        if (_playerUI.IsPaused)
            return;

        SoundEffectsManager.Instance.PlayShotSound(true);
        Bullet bulletInstance = BulletPool.Instance.Get();
        bulletInstance.transform.position = _aim.ShotPoint.position;
        bulletInstance.Direction = _aim.Direction;
    }
}
