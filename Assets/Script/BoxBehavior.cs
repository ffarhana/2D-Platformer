using System.Collections;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private int numberOfCollectibles = 3;
    [SerializeField] private AudioSource destroySoundEffect;

    private int jumpsOnBox = 0;
    private int requiredJumps = 3;

    public PlayerLife _Playerlifescript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JumpOnBox(collision.gameObject);
            Debug.Log("Player collided with Box");
        }
    
    }

    private void JumpOnBox(GameObject player)
    {
        if (jumpsOnBox < requiredJumps)
        {
            // Increment the jumpsOnBox counter
            jumpsOnBox++;

            // Perform your jump-on-box behavior
            // For example, play a sound or trigger an animation

            Debug.Log("Jumped on Box: " + jumpsOnBox);
        }
        else
        {
            // If enough jumps have been made, destroy the box
            DestroyBox();
        }

    }

    private void DestroyBox()
    {
        // Play destroy sound effect
        if (destroySoundEffect != null)
        {
            destroySoundEffect.PlayOneShot(destroySoundEffect.clip);
        }

        // Spawn collectibles
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            SpawnCollectible();
        }

        // Destroy the box
        Destroy(gameObject);
    }

    private void SpawnCollectible()
    {
        if (collectiblePrefab != null)
        {
            // Instantiate a collectible at the box's position
            Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
        }
    }
}
