using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //change starting health if it applies
    [SerializeField] private int startingHealth = 2;

    private void Start()
    {
        currentHealth = startingHealth;
    }
    //When the player "hits" the entity, it takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }
    //Removes the entity when health drops to 0
    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}