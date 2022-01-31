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
    public GameObject smallHealthPotion;
    public GameObject healthPotion;
    private Transform Knight;


    void Start()
    {
        currentHealth = maxHealth;
        Knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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

        // Spawn de Items en funcion del enemigo muerto.

        if(gameObject.name == "Boss_Adventure")
        {
            Instantiate(rope, gameObject.transform.position, Quaternion.identity);
            Instantiate(healthPotion,gameObject.transform.position,Quaternion.identity);
            Instantiate(healthPotion, gameObject.transform.position, Quaternion.identity);
        }
        else if (gameObject.name == "Boss_Red_Hat")
        {
            Instantiate(healthPotion,gameObject.transform.position,Quaternion.identity);
            Instantiate(smallHealthPotion, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(gameObject, 1);
    }
}
