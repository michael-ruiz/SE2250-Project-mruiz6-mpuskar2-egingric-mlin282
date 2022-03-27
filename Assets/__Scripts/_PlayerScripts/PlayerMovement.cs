using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public static float speedMultiplier = 1;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movement;
    private float _dashCooldown;

    // Get animator and rigidbody for every player
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        speedMultiplier = 1;
    }

    // Update is called once per frame
   void Update()
{

    _movement.x = Input.GetAxisRaw("Horizontal");
    _movement.y = Input.GetAxisRaw("Vertical");

    if (_movement != Vector2.zero)
    {
         _animator.SetFloat("LastHorizontal", _movement.x);
         _animator.SetFloat("LastVertical", _movement.y);
     }

     _animator.SetFloat("Speed", _movement.sqrMagnitude);
}

    // Updated evry fixed amount of frames
    void FixedUpdate()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.Space))
        {
            if (3 <= _dashCooldown)
            {
                speed = 50;
                _dashCooldown = 0;
                StartCoroutine(ExecuteAfterTime(0.1f)); // Delay of 0.1 seconds
            }
        }

        // Check if the multiplier is greater than 1, and if it is reset it after 5 seconds
        if (speedMultiplier > 1)
        {
            StartCoroutine(ResetMultiplierDelay(5));
        }

        _dashCooldown += Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + _movement.normalized * speed * speedMultiplier * Time.fixedDeltaTime); 
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        speed = 5;
    }

    IEnumerator ResetMultiplierDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        speedMultiplier = 1;
    }
}
