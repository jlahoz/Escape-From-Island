using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public GameObject enemy;

    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void update()
    {

    }

    public void TakeDamage(int damage)
    {
        // Resetear el tiempo de aturdir a Jack cada vez que recibe da�o.

        JackScript.dazedTime = JackScript.startDazedTime;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("isDead", true);

        Destroy(gameObject, 1);

    }
}
