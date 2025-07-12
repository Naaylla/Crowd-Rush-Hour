using UnityEngine;

public class IdiotSpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;           // Positions où les idiots peuvent apparaître
    public GameObject[] idiotPrefab;            // Préfabriqué de l'idiot
    private float timer;
    private float timeToSpawn;

    

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0f;
            ResetTimer();

            int randIndex = Random.Range(0, spawnPoints.Length);
            int randPrefab = Random.Range(0, idiotPrefab.Length);
            Instantiate(idiotPrefab[randPrefab], spawnPoints[randIndex].position, Quaternion.identity);
        }
    }

    void ResetTimer()
    {
        timeToSpawn = Random.Range(0f,1f); // Temps aléatoire entre 1 et 3 secondes
    }
}
