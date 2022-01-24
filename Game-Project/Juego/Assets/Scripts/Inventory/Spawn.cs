using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private KnightMovement KnightMovement;

    private void start()
    {

    }

    public void SpawnDroppedItem()
    {
        player = GameObject.Find("Knight").GetComponent<Transform>();

        if (player.transform.localScale.x > 0)
        {
            Vector2 playerPos = new Vector2(KnightMovement.player.position.x + 0.5f, KnightMovement.player.position.y - 0.2f);
            Instantiate(item, playerPos, Quaternion.identity);
        } else
        {
            Vector2 playerPos = new Vector2(KnightMovement.player.position.x - 0.5f, KnightMovement.player.position.y - 0.2f);
            Instantiate(item, playerPos, Quaternion.identity);
        }
    }
}
