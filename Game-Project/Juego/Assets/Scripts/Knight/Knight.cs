using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{

    public int maxHealth = 100;
    public static int currentHealth; 

    public HealthBar healthBar;
    public GameObject DeathMenuUI;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    public void Death()
    {
        DeathMenuUI.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
    }
}
