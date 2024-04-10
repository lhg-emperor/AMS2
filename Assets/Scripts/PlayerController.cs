using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spi;
    private Animator ani;


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private float dirX = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
      
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
        AnimationUpdate();
    }
    private void AnimationUpdate()
    {
         if (dirX > 0)
        {
            ani.SetBool("running",true);
            spi.flipX = false;
        }
         else if(dirX < 0)
        {
            ani.SetBool("running", true);
            spi.flipX = true;
        }
        else
        {
            ani.SetBool("running",false);
        }
    }
}