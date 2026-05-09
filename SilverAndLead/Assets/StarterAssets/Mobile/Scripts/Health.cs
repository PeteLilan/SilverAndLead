using System;
using UnityEngine;
using StarterAssets;

public class Health : MonoBehaviour
{
    public FirstPersonController x;
    public event Action OnDeath;

    [SerializeField] float maxHealth = 100f;
    float currentHealth;
    float score;

    void Start()
    {
        currentHealth = maxHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            x = player.GetComponent<FirstPersonController>();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0)
        {
            FirstPersonController.score = FirstPersonController.score + 100;
            Die();
        }
    }

    void Die()
    { 
        Destroy(gameObject);
    }
}