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

            _Playerlifescript.collectibles++;
            //UpdatecollectiblesText();
            _Playerlifescript.collectiblesText.text = "Collectibles : " + _Playerlifescript.collectibles;
        }

        if (collision.gameObject.CompareTag("HealthItem"))
        {
            HealthSoundEffect.Play();
            Destroy(collision.gameObject);

            // Increment currentHealth, but ensure it doesn't exceed 10
            _Playerlifescript.currentHealth = Mathf.Min(_Playerlifescript.currentHealth + 1, 10);

            _Playerlifescript.healthText.text = "Health : " + _Playerlifescript.currentHealth;
        }


    }

    

}
