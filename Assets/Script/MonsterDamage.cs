using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damageAmount = 2;
    public PlayerLife playerHealth;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the TakeDamage function on the PlayerLife script attached to the player GameObject
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damageAmount);
                Debug.Log("Player damaged by monster");
            }
        }
    }

}
