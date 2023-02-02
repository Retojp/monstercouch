using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _enemyCount = 100;

    float _screenWidth;
    float _screenHeight; 

    public void SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randomXPosition = UnityEngine.Random.Range(-8.4f, 8.4f);
        float randomYPosition = UnityEngine.Random.Range(-4.4f, 4.4f);
        Instantiate(_enemyPrefab, new Vector2(randomXPosition,randomYPosition),Quaternion.identity);
    }
}
