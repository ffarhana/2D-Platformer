using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;


    [SerializeField] public Text healthText; // Reference to a UI text component for displaying health
    public int maxHealth = 100;
    public int currentHealth;

    public float bounceForce = 5f; // Adjust the force as needed

    //box jump 3x 
    [SerializeField] private GameObject collectiblePrefab;
    private int jumpsRemaining = 3;

    [SerializeField] public Text collectiblesText;
    public int collectibles = 0;



    [SerializeField] private AudioSource takeDamageSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth; // Set the initial current health to the maximum health value

        UpdateHealthText();
        UpdatecollectiblesText();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            int damageAmount = 1;
            TakeDamage(damageAmount);
            Debug.Log("Trapped");

        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            JumpOnBox(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
        }

    }
    //box jump start
    private void JumpOnBox(GameObject box)
    {
        if (jumpsRemaining > 0)
        {
            jumpsRemaining--;
            Debug.Log("Box Jumped. Jumps Remaining: " + jumpsRemaining);

            // Apply bounce force when jumping on the box
            //BounceBack();
        }
        else
        {
            // Add your collectible spawn logic here
            SpawnCollectible(box.transform.position);
            Destroy(box);
        }
    }


    private void SpawnCollectible(Vector2 spawnPosition)
    {
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        collectibles++;
        UpdatecollectiblesText();
        collectSoundEffect.Play();
    }

    //box jump end

    public void TakeDamage(int damageAmount)
    {
        currentHealth--; // Decrease the player's current health
        Debug.Log("Player Health: " + currentHealth);

        takeDamageSoundEffect.Play();

        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Apply bounce force when taking damage
            BounceBack();
        }

    }


    private void BounceBack()
    {
        // Apply a force to the player in the opposite direction
        rb.AddForce(new Vector2(-bounceForce, 5f), ForceMode2D.Impulse);

        Invoke("TriggerBounceAnimation", 0.1f);

    }

    private void TriggerBounceAnimation()
    {
        // Trigger the bounce animation
        anim.SetBool("Hit", true);
        Invoke("ResetBounceAnimation", 0.1f);
       
    }
    private void ResetBounceAnimation()
    {
        // Reset the bounce animation
        anim.SetBool("Hit", false);
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;//change Body Type from dynamic to static when touches the spike
        anim.SetTrigger("death");

        Invoke("RestartLevel", 2f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health : " + currentHealth;
            
        }

    }

    void UpdatecollectiblesText()
    {
        collectiblesText.text = "Collectible : " + collectibles;
    }

}
