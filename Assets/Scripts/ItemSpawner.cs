using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 10;
    [SerializeField] float spawnRadius = 5;
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int powerUpSpawnDelay = 12;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());   
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnCheckpointRoutine() {
        while(true) {
            yield return new WaitForSeconds(checkpointSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * 5; //spawnRadius;
            //Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
            //GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            GameObject checkpoint = Instantiate(checkpointPrefab, randomPosition, Quaternion.identity) as GameObject;
            checkpoint.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, -11);
        }
    }

    IEnumerator SpawnPowerUpRoutine() {
        while(true) {
            yield return new WaitForSeconds(powerUpSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * 5; //spawnRadius;
            //Instantiate(powerUpPrefab, randomPosition, Quaternion.identity)
            int random = Random.Range(0, powerUpPrefab.Length);
            GameObject powerUp = Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity) as GameObject;
            powerUp.transform.position = new Vector3(powerUp.transform.position.x, powerUp.transform.position.y, -11);
        }
    }
}
