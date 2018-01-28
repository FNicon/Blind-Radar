using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;
    public float yMin;
    public float yMax;
    public GameObject[] spawnThings;
    public bool sequenceSpawn = false;
    private int i = 0;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Update()
    {

    }
    public void Spawn()
    {
        if (i >= spawnThings.Length && sequenceSpawn)
        {
            CancelInvoke();
            BossManager.Instance.SpawnBoss();
        } else
        {
            if (!sequenceSpawn)
            {
                i = Random.Range(0, spawnThings.Length);
            }
            float y = Random.Range(yMin, yMax);
            Vector3 spawnPosition = new Vector3(transform.position.x, y);
            Instantiate(spawnThings[i], spawnPosition, transform.rotation);
            if (i < spawnThings.Length)
            {
                i++;
            }
        }
        
    }
}
