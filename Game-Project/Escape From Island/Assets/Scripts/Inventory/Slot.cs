using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    public void DropItem()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
            inventory.isFull[i] = false; // Control slots usados
        }
    }
}
