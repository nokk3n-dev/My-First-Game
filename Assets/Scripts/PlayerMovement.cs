using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D player;
    private BoxCollider2D playerCollide;
    private SpriteRenderer playerSprite;
    private Animator playerAnimation;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerCollide = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

            if (Input.GetButtonDown("Jump") && IsOnGround())
            {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                jumpSoundEffect.Play();
            }

            UpdateAnimationState();
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        // Running to idle animation control
        if (dirX > 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (player.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (player.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        playerAnimation.SetInteger("state", (int)state);
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(playerCollide.bounds.center, playerCollide.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
