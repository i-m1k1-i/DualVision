using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _spawnMin;
    [SerializeField] private Transform _spawnMax;


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
        Vector3 spawnPosition = GetRandomVector3(_spawnMin.position, _spawnMax.position);
        enemy.transform.position = spawnPosition;
        Debug.Log("Spawn");
    }


    private Vector3 GetRandomVector3(Vector3 min, Vector3 max)
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        float z = Random.Range(min.z, max.z);

        return new Vector3(x, y, z);
    }
}
