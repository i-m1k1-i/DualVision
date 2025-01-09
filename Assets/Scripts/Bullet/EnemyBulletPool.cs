using UnityEngine;
using UnityEngine.Pool;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool Instance;

    [SerializeField] private EnemyBullet _bulletPrefab;

    private ObjectPool<EnemyBullet> _pool;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    public EnemyBullet Get()
    {
        return _pool.Get();
    }

    public void Release(EnemyBullet bullet)
    {
        _pool.Release(bullet);
    }

    private void InitializePool()
    {
        _pool = new ObjectPool<EnemyBullet>(
            createFunc: () => Instantiate(_bulletPrefab),
            actionOnGet: (bullet) => bullet.gameObject.SetActive(true),
            actionOnRelease: (bullet) => bullet.gameObject.SetActive(false),
            actionOnDestroy: (bullet) => Destroy(bullet),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 20);
    }
}
