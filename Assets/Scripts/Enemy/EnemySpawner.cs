using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Transform _spawnMin;
    [SerializeField] private Transform _spawnMax;
    [SerializeField] private float _newWaveInterval;
    [SerializeField] private NewWaveAlert _alert;

    private float _lastSpawnTime;
    private float _lastWaveStartTime;
    private bool _spawning = true;
    private int _wave = 1;
    private bool _isProcessingNewWave;

    private void Update()
    {
        if (_isProcessingNewWave)
        {
            return;
        }

        if (IsTimePassed(_lastSpawnTime, _spawnInterval) && _spawning)
        {
            Spawn();
            _lastSpawnTime = PlayTime.Current;
        }

        if (IsTimePassed(_lastWaveStartTime, _newWaveInterval))
        {
            _spawning = false;
            if (Enemy.LiveEnemies == 0)
            {
                StartNewWave();
            }
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(GetRandomEnemy());
        Vector3 spawnPosition = GetRandomVector3(_spawnMin.position, _spawnMax.position);
        enemy.transform.position = spawnPosition;
        Debug.Log("Spawn");
    }

    private async void StartNewWave()
    {
        _isProcessingNewWave = true;
        await NewWave();
        _isProcessingNewWave = false;
    }

    private async Task NewWave()
    {
        _wave++;
        await _alert.StartAlert(_wave);
        _spawning = true;
        _spawnInterval *= 0.7f;
        _lastWaveStartTime = PlayTime.Current;
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

    private bool IsTimePassed(float since, float interval)
    {
        return PlayTime.Current - since >= interval;
    }
}
