using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public int StunEnemiesAlive = 4;

    public GameObject rope;
    private Transform Knight;
    private Vector3 posicionItem;


    void Start()
    {
        currentHealth = maxHealth;
        Knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        RedHatScript.dazedTime = RedHatScript.startDazedTime * StunEnemiesAlive;

        currentHealth -= damage;
        Debug.Log("Daño");  

        if (currentHealth <= 0)
        {
            Die();
            StunEnemiesAlive += 1;
        }
        animator.SetTrigger("takeDamage");
    }

    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("isDead", true);

        if(gameObject.name == "Boss_Adventure")
        {

        }

        Destroy(gameObject, 1);


    }
}
