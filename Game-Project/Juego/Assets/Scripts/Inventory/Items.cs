using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Inventory inventory;
    int i;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void smallPotion()
    {
        Knight.currentHealth += 25;
        Destroy(gameObject);
        inventory.isFull[i] = false;
    }

    public void Potion()
    {
        Knight.currentHealth += 50;
        Destroy(gameObject);
        inventory.isFull[i] = false;
    }

}
