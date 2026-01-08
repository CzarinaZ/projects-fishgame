using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyHealth : MonoBehaviour
{
    //Enemy's starting health
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        flash = Get.Component<Flash>();
        knockback = Get.Component<Knockback>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    //When the player "hits" the enemy, it takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
    }

    //Removes the entity when health drops to 0
    public void DetectDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
