using System;
using UnityEngine;
using StarterAssets;

public class Health2 : MonoBehaviour
{
    public event Action OnDeath;
    [SerializeField] float maxHealth = 250f;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0)
        {
            ScoreDisplay.score = ScoreDisplay.score + 250;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
