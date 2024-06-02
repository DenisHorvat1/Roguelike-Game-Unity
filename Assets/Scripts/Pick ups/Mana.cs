using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float manaAmount = 1000f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerMagicSystem playerHealthComponent = other.GetComponent<PlayerMagicSystem>();

        if (playerHealthComponent != null)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            playerHealthComponent.AddMana(manaAmount);
            gameObject.SetActive(false);
        }
    }

}
