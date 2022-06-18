using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] HP;
    //public int hpRemaining;

    private float health = 0f;
    [SerializeField] private float maxHealth = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float update) 
    {
        health += update;

        
        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f) {
            health = 0f;
            HP[(int) health].enabled = false;
            Debug.Log("Player Respawn");
        } else if (health < maxHealth) {
            HP[(int) health].enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        //hpRemaining = (int) health;
        //HP[hpRemaining].enabled = false;
    }
}
