using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    public const string CollectiblesKey = "PlayerCollectibles";
    public const string HealthKey = "PlayerHealth";

    // Save player data to PlayerPrefs
    public void SavePlayerData()
    {
        PlayerPrefs.SetInt(CollectiblesKey, PlayerLife.collectibles);
        PlayerPrefs.SetInt(HealthKey, PlayerLife.currentHealth);
        PlayerPrefs.Save();
    }

    // Load player data from PlayerPrefs
    public void LoadPlayerData()
    {
        // If the keys exist, load the saved values; otherwise, use default values (0 collectibles, 100 health)
        PlayerLife.collectibles = PlayerPrefs.GetInt(CollectiblesKey, 0);
        PlayerLife.currentHealth = PlayerPrefs.GetInt(HealthKey, 100);
    }
}


