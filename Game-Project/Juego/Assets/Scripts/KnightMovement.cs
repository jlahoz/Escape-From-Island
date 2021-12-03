using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Ground;

    void Start()
    {
        // Obtener componente RigidBody
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Valores en funcion de lo que el usuario pulsa (-1 , 1)
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-0.1499787f, 0.1499787f, 0.1499787f);
        } else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(0.1499787f, 0.1499787f, 0.1499787f);
        }

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Ground = true;
        } else
        {
            Ground = false;
        }
    

        if (Input.GetKeyDown(KeyCode.W) && Ground)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Movimiento del eje X del personaje
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

}
