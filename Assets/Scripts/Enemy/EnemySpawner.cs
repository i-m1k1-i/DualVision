using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay;

    private float _spawnTime;

    private void Update()
    {
        _spawnTime += Time.deltaTime;
        if (_spawnTime >= _spawnDelay)
        {
            Spawn();
            _spawnTime = 0;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemy);
        enemy.transform.position = transform.position;
        enemy.Initialize(_player);
        Debug.Log("Spawn");
    }
}
