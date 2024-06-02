using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float health = 10f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerHealthComponent playerHealthComponent = other.GetComponent<PlayerHealthComponent>();

        if (playerHealthComponent != null)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            playerHealthComponent.AddHealth(health);
            gameObject.SetActive(false);
        }
    }
}
