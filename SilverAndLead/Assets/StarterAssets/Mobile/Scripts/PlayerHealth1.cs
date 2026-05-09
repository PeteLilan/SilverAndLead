using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    public FirstPersonController x;
    public StarterAssetsInputs playerInputs;
    // ─── Settings ────────────────────────────────────────────────────────
    [Header("Health")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float invincibilityDuration = 1.5f;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;

    // ─── State ───────────────────────────────────────────────────────────
    bool isInvincible;
    float invincibilityTimer;
    float score;

    // ─── Lifecycle ───────────────────────────────────────────────────────
    void Start()
    {

        currentHealth = maxHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            x = player.GetComponent<FirstPersonController>();
            if (playerInputs == null)
            {
                playerInputs = player.GetComponent<StarterAssetsInputs>();
            }
        }
    }

    void Update()
    {
        HandleInvincibility();
        healthText.text = $"HP: {currentHealth}";
        scoreText.text = $"Score: {FirstPersonController.score}";
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
        if (playerInputs != null)
        {
            playerInputs.cursorLocked = false;
            playerInputs.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Invoke(nameof(GameOver), 1f);  // Wait for death animation
    }

    void GameOver()
    {

        SceneManager.LoadScene("GameOver");
    }
}