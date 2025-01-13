using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static float _damageMultiplier = 1;
    private static int _liveEnemies;
    public static float DamageMultiplier => _damageMultiplier;
    public static int LiveEnemies => _liveEnemies;

    protected virtual void Awake()
    {
        _liveEnemies++;
    }

    public static void SetDamageMultiplier(float multiplier)
    {
        _damageMultiplier = multiplier;
    }

    private void OnDestroy()
    {
        _liveEnemies--;
    }
}
