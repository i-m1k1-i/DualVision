using System.Threading.Tasks;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NewWaveAlert _alert;

    [Header("Wave settings")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _newWaveInterval;

    private EnemySpawner _spawner;
    private float _lastSpawnTime;
    private float _lastWaveStartTime;
    private bool _isProcessingNewWave;
    private bool _spawning = true;
    private int _wave = 1;
    private string _changingsText;

    private void Start()
    {
        _spawner = GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        if (_isProcessingNewWave)
            return;


        if (IsTimePassed(_lastSpawnTime, _spawnInterval) && _spawning)
        {
            _spawner.Spawn();
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

    private async void StartNewWave()
    {
        _isProcessingNewWave = true;
        await NewWave();
        _isProcessingNewWave = false;
    }

    private async Task NewWave()
    {
        _wave++;
        _changingsText = "";
        if (_wave <= 6)
        {
            _spawnInterval *= 0.7f;
            _changingsText = "Spawn rate increased";
        }
        if (_wave == 7)
        {
            Enemy.SetDamageMultiplier(2);
            _changingsText = "Enemy damage x2";
        }
        if (_wave == 9)
        {
            Enemy.SetDamageMultiplier(4);
            _changingsText = "Enemy damage x2";
        }

        await _alert.StartAlert(_wave, _changingsText);
        _spawning = true;
        _lastWaveStartTime = PlayTime.Current;
    }

    private bool IsTimePassed(float since, float interval)
    {
        return PlayTime.Current - since >= interval;
    }
}
