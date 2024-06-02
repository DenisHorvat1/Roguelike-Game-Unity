using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerInverntory playerInverntory = other.GetComponent<PlayerInverntory>();

        if (playerInverntory != null)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            playerInverntory.CoinCollected();
            gameObject.SetActive(false);
        }
    }
}
