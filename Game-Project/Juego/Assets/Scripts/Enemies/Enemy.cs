using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public int StunEnemiesAlive = 4;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void update()
    {
       
    }

    // Take Damage de los enemigos

    public void TakeDamage(int damage)
    {
        // Resetear el tiempo de aturdir a Enemigos cada vez que recibe daño.

        JackScript.dazedTime = JackScript.startDazedTime * StunEnemiesAlive;
        SantaScript.dazedTime = SantaScript.startDazedTime * StunEnemiesAlive;
        CatnDogScript.dazedTime = CatnDogScript.startDazedTime * StunEnemiesAlive;

        currentHealth -= damage;

        Debug.Log("Daño");  

        if (currentHealth <= 0)
        {
            Die();
            StunEnemiesAlive += 1;
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("isDead", true);

        Destroy(gameObject, 1);

    }
}
