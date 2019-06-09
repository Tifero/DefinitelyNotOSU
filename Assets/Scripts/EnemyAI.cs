using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public float spawnDelay;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    private void SpawnObject()
    {
        Instantiate(enemy, new Vector3(Random.Range(-3.5F, 3.5F), Random.Range(-4.5F, 4.5F), 0),
            Quaternion.identity);
    }
}