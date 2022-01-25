using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Inventory inventory;

    int i;
    int speedPotionTime = 2;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void smallHealthPotion()
    {
        Knight.currentHealth += 25;
        Destroy(gameObject);
        inventory.isFull[i] = false;
    }

    public void healthPotion()
    {
        Knight.currentHealth += 50;
        Destroy(gameObject);
        inventory.isFull[i] = false;
    }

    public void speedPotion()
    {

    }
}
