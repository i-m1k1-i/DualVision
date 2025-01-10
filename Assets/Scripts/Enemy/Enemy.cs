using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static int _killedEnemies;
    public static int KilledEnemies => _killedEnemies;

    protected virtual void Awake()
    {
        EnemyHealth health = GetComponent<EnemyHealth>();
        health.OnDeath += CountDie;
    }

    private void CountDie()
    {
        _killedEnemies++;
    }
}
