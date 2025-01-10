using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _spawnMin;
    [SerializeField] private Transform _spawnMax;
    [SerializeField] private float _difficultyIncreasingTime;


    private float _lastSpawnTime;
    private float _lastDifIncreasingTime;

    private void Update()
    {
        if (PlayTime.Current - _lastSpawnTime >= _spawnDelay)
        {
            Spawn();
            _lastSpawnTime = PlayTime.Current;
        }

        if (PlayTime.Current - _lastDifIncreasingTime >= _difficultyIncreasingTime)
        {
            _spawnDelay *= 0.7f;
            _lastDifIncreasingTime = PlayTime.Current;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(GetRandomEnemy());
        Vector3 spawnPosition = GetRandomVector3(_spawnMin.position, _spawnMax.position);
        enemy.transform.position = spawnPosition;
        Debug.Log("Spawn");
    }

    private Enemy GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, _enemies.Length);
        return _enemies[randomIndex];
    }

    private Vector3 GetRandomVector3(Vector3 min, Vector3 max)
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        float z = Random.Range(min.z, max.z);

        return new Vector3(x, y, z);
    }
}
