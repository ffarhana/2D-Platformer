using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemCollector : MonoBehaviour
{
    
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource HealthSoundEffect;

    public PlayerLife _Playerlifescript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Collectible"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);

            PlayerLife.collectibles++;
            //UpdatecollectiblesText();
            _Playerlifescript.collectiblesText.text = "Collectibles : " + PlayerLife.collectibles;
        }

        if (collision.gameObject.CompareTag("HealthItem"))
        {
            HealthSoundEffect.Play();
            Destroy(collision.gameObject);

            // Increment currentHealth, but ensure it doesn't exceed 10
            PlayerLife.currentHealth = Mathf.Min(PlayerLife.currentHealth + 1, 10);

            _Playerlifescript.healthText.text = "Health : " + PlayerLife.currentHealth;
        }


    }

    

}
