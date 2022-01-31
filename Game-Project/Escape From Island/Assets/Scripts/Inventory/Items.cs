using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Tiempos de las pociones
    public int speedPotionTime = 20;
    public int jumpPotionTime = 30;
    public int damagePotionTime = 60;

    // Items de la barca usados.
    public static bool usedWood = false;
    public static bool usedStone = false;
    public static bool usedRope = false;

    private Inventory inventory;
    private Transform posicion;

    private GameObject slot;
    private Slot slotScript;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Pociones

    public void smallHealthPotion()
    {
        Knight.currentHealth += 25;
        Destroy(gameObject);
        useSlotItem();

    }

    public void healthPotion()
    {
        Knight.currentHealth += 50;
        Destroy(gameObject);
        useSlotItem();
    }

    public void speedPotion()
    {
        KnightMovement.Speed += 1;
        useSlotItem();

        posicion = GetComponent<Transform>();

        posicion.localScale = new Vector3(0, 0, 0);

        StartCoroutine(speedPotionTimer());

    }

    IEnumerator speedPotionTimer()
    {
        yield return new WaitForSeconds(speedPotionTime);
        KnightMovement.Speed -= 1;
        Destroy(gameObject);
    }

    public void jumpPotion()
    {
        KnightMovement.JumpForce += 50;
        useSlotItem();

        posicion = GetComponent<Transform>();
        posicion.localScale = new Vector3(0, 0, 0);

        StartCoroutine(jumpPotionTimer());
    }

    IEnumerator jumpPotionTimer()
    {
        yield return new WaitForSeconds(jumpPotionTime);
        KnightMovement.JumpForce -= 50;
        Destroy(gameObject);
    }

    public void damagePotion()
    {
        KnightCombat.attackDamage += 20;

        useSlotItem();

        posicion = GetComponent<Transform>();
        posicion.localScale = new Vector3(0, 0, 0);

        StartCoroutine(damagePotionTimer());
    }
    IEnumerator damagePotionTimer()
    {
        yield return new WaitForSeconds(damagePotionTime);
        KnightCombat.attackDamage -= 20;
        Destroy(gameObject);
    }

    // Items de la barca

    public void woodItem()
    {
        if (BoatScript.canUseItem)
        {
            usedWood = true;
            useSlotItem();
            Destroy(gameObject);
        }
    }

    public void stoneItem()
    {
        if (BoatScript.canUseItem)
        {
            usedStone = true;
            useSlotItem();
            Destroy(gameObject);
        }
    }

    public void ropeItem()
    {
        if (BoatScript.canUseItem)
        {
            usedRope = true;
            useSlotItem();
            Destroy(gameObject);
        }
    }

    // Liberar slot una vez usado item

    private void useSlotItem()
    {
        slot = transform.parent.gameObject;
        Debug.Log(slot);
        slotScript = slot.GetComponent<Slot>();
        inventory.isFull[slotScript.i] = false;
    }
}