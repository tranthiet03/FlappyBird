using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 3f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (!GameManager.Instance.IsStartGame()) return;
        if (Input.GetMouseButtonDown(0)|| Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            GameManager.Instance.AddPoint();
        }
        if(collision.CompareTag("Pipe"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
