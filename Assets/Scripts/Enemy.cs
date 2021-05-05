using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player; 
    [SerializeField] int health = 1; 
    [SerializeField] float speed = 1;
    [SerializeField] int scorePoints = 100;
    [SerializeField] AudioClip impactClip;
    //[SerializeField] AudioClip deadClip;

    public void Start() {
        player = FindObjectOfType<Player>().transform;
        // Allow enemies can appear from a determined point
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }

    private void Update() {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * Time.deltaTime;
    }

    public void TakeDamage() {
        health--; 
        AudioSource.PlayClipAtPoint(impactClip, transform.position);

        if(health <= 0) {
            GameManager.Instance.Score += scorePoints;
            //AudioSource.PlayClipAtPoint(deadClip, transform.position);
            //yield return new WaitForSeconds(2);
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
