using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    #region Public Values
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer SpriteRenderer;

    #endregion

    #region Private Values
    private Vector2 movement;
    private bool TurnLeft;
    

    #endregion

    private void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        TurnPlayer();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        #region Direction
        if (movement.x != 0 || movement.y != 0)
        {
            // Last movement X
            if (movement.x > 0)
            {
                animator.SetFloat("XPlayer", 1f);
            }
            else if (movement.x < 0)
            {
                animator.SetFloat("XPlayer", -1f);
            }
            else
            {
                animator.SetFloat("XPlayer", 0f);
            }

            // Last movement Y
            if (movement.y > 0)
            {
                animator.SetFloat("YPlayer", 1f);
            }
            else if (movement.y < 0)
            {
                animator.SetFloat("YPlayer", -1f);
            }
            else
            {
                animator.SetFloat("YPlayer", 0f);
            }
        }
        #endregion
        
    }

    private void TurnPlayer()
    {
        if (animator.GetFloat("Horizontal") < 0)
        {
            TurnLeft = true;
        }
        else if (animator.GetFloat("Horizontal") > 0)
        {
            TurnLeft = false;
        }

        if (TurnLeft)
        {
            SpriteRenderer.flipX = true;
        }
        else
        {
            SpriteRenderer.flipX = false;
        }
        
    }
}
