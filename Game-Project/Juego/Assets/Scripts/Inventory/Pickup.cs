using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    public GameObject itemButton;

    private void start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
}
