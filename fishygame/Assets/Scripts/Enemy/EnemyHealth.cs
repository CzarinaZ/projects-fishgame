using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyHealth : MonoBehaviour
{
    //Enemy's starting health
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    //When the player "hits" the enemy, it takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath(){
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
