using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBulletMovement : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    /*
    private void OnCollisionStay2D(Collision2D collision) {
        if (gameObject != null && !collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet")) {
            if (collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
                Destroy(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
    */

    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (gameObject != null && !collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet")) {
            if (collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
                Destroy(gameObject);
            } else {    
                Destroy(gameObject);
            }
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
