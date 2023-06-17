using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float Xspeed;
    [SerializeField] private float Yspeed;
    private Rigidbody2D body;
    [SerializeField] private bool inAir = false;
    [SerializeField] private bool inWater = false;

    void Start()
    {
        
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if (inWater == false)
        {
            if (Input.GetKey(KeyCode.W) && inAir == false)
            {
                body.velocity = new Vector2(body.velocity.x, 5);
            }
            if (Input.GetKey(KeyCode.A))
            {
                body.velocity = new Vector2(-6, body.velocity.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                body.velocity = new Vector2(6, body.velocity.y);
            }
        }
        if (inWater == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                body.velocity = new Vector2(body.velocity.x, 2);
            }
            if (Input.GetKey(KeyCode.S))
            {
                body.velocity = new Vector2(body.velocity.x, -2);
            }
            if (Input.GetKey(KeyCode.A))
            {
                body.velocity = new Vector2(-3, body.velocity.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                body.velocity = new Vector2(3, body.velocity.y);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = false;
        }
        if (other.gameObject.CompareTag("water"))
        {
            inWater = true;
            body.gravityScale = 0;
            body.velocity = new Vector2(0.4f * body.velocity.x, 0.4f * body.velocity.y);
            body.drag = 1.4f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = true;
        }
        if (other.gameObject.CompareTag("water"))
        {
            inWater = false;
            body.gravityScale = 1;
            body.drag = 0.2f;
        }
    }

}
