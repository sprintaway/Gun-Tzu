using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDetection : MonoBehaviour
{
   private Transform target;
    //public Image[] HP;
    //public int hpRemaining;
    
    // public float speed = 3f;
    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    //public float lineOfSight;

    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1;
    private float nextFireTime;
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                //hpRemaining = hpRemaining - attackDamage;
                //HP[hpRemaining].enabled = false;
                canAttack = 0f;
            } else {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") {
            target = null;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && nextFireTime < Time.time) {
            //float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        
    }
}
