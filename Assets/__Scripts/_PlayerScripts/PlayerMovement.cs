using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float defaultSpeed;
    public static float speedMultiplier = 1;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Vector2 movement;
    protected float dashCooldown;

    // Get animator and rigidbody for every player
    void Awake()
    {
        defaultSpeed = speed;

        rb = GetComponent<Rigidbody2D>();
        speedMultiplier = 1;
        if (GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
   void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero && animator != null)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    // Updated every fixed amount of frames
    void FixedUpdate()
    {
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        UniqueMovement();

        // Check if the multiplier is greater than 1, and if it is reset it after 5 seconds
        if (speedMultiplier > 1)
        {
            StartCoroutine(ResetMultiplierDelay(5));
        }

        dashCooldown += Time.fixedDeltaTime;
        rb.MovePosition(rb.position + speed * speedMultiplier * Time.fixedDeltaTime * movement.normalized); 
    }

    protected virtual void UniqueMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (3 <= dashCooldown)
            {
                speed = 50;
                dashCooldown = 0;
                StartCoroutine(ExecuteAfterTime(0.1f)); // Delay of 0.1 seconds
            }
        }
    }

    protected IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        speed = defaultSpeed;
    }

    protected IEnumerator ResetMultiplierDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        speedMultiplier = 1;
    }
}
