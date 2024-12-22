using UnityEngine;
using UnityEngine.UI; // For accessing UI elements

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;       // Reference to the health bar Slider
    public Text healthText;        // Reference to the health text (optional)

    void Start()
    {
        currentHealth = maxHealth; // Initialize health

        // Initialize the health bar and text
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            // Add game-over logic here
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        // Update the health bar
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // Update the health text
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        }
    }
}
