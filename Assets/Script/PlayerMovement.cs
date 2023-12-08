using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 10f;

    [SerializeField] public Rigidbody2D rb;
    
    public bool isJumping;

    private Animator anim;

    private SpriteRenderer sprite;

    [SerializeField] private AudioSource jumpSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       // Move the player horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        if (horizontalInput != 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }

            // Jump if the player is grounded and the jump button (e.g., space) is pressed
            if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("IsJumping", true);
        }
            else
        {
            anim.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            isJumping = false;
        }
    }

        private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            isJumping = true;
        }
    }
}
