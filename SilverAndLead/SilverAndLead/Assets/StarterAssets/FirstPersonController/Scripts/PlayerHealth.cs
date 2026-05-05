using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // ─── Settings ────────────────────────────────────────────────────────
    [Header("Health")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float invincibilityDuration = 1.5f;
    [SerializeField] TextMeshProUGUI healthText;

    // ─── State ───────────────────────────────────────────────────────────
    bool isInvincible;
    float invincibilityTimer;

    // ─── Lifecycle ───────────────────────────────────────────────────────
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleInvincibility();
        healthText.text = $"HP: {currentHealth}";
    }

    // ─── Invincibility Flash ─────────────────────────────────────────────
    void HandleInvincibility()
    {
        if (!isInvincible) return;

        invincibilityTimer -= Time.deltaTime;
        // Flash effect: toggle sprite visibility

        if (invincibilityTimer <= 0)
        {
            isInvincible = false;
        }
    }

    // ─── Public API ──────────────────────────────────────────────────────
    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
        AudioManager.Instance?.PlayHit();

        // Start invincibility window
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }

    void Die()
    {
        AudioManager.Instance?.PlayDeath();

        Invoke(nameof(GameOver), 1f);  // Wait for death animation
    }

    void GameOver()
    {

    }
}