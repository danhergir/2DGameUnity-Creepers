using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] int health = 3;
    public bool powerShot;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage();
            
            if(!powerShot)
                Destroy(gameObject);

            health--;   
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
