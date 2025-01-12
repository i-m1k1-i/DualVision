using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform _spawnMin;
    [SerializeField] private Transform _spawnMax;

    public void Spawn()
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
