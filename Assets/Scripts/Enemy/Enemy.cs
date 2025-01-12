using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static int _liveEnemies;

    public static int LiveEnemies => _liveEnemies;

    protected virtual void Awake()
    {
        _liveEnemies++;
    }

    private void OnDestroy()
    {
        _liveEnemies--;
    }
}
