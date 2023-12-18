using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField]private float bounceForce = 13f;
    [SerializeField]private Animator platformAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

            // Trigger the bounce animation
            if (platformAnimator != null)
            {
                platformAnimator.SetTrigger("Bounce");
            }
        }
    }
}
