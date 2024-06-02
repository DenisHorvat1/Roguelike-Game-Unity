using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : MonoBehaviour
{
    public float MaxHealth = 50f;
    private float currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }


    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) Destroy(this.gameObject);
    }

    public void AddHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;
        healthBar.SetHealth(currentHealth);

        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
            healthBar.SetHealth(currentHealth);
        }
    }
}
