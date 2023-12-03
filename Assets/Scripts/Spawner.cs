using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public Spawner instance;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public GameObject player;
    public int enemyDistanceSpawn = 15;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    void Awake()
    {
        instance = this;
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
    }

    void SpawnEnemy()
    {
        Vector3 distance = player.transform.position - instance.transform.position;
        if (distance.magnitude < enemyDistanceSpawn)
        {
            int ndx = Random.Range(0, prefabEnemies.Length);
            GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);
            Vector3 pos = this.transform.position;
            go.transform.position = pos;
        }
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
