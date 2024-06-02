using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float MaxHealth = 50f;
    private float currentHealth;



    private void Awake()
    {
        currentHealth = MaxHealth;
    }


    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;

        if (currentHealth <= 0) Destroy(this.gameObject);
    }
}
