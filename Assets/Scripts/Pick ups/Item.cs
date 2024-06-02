using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public List<Spell> spells;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerMagicSystem playerMagicComponent = other.GetComponent<PlayerMagicSystem>();

        if (playerMagicComponent != null)
        {
            FindObjectOfType<AudioManager>().Play("ItemPickup");
            Spell randomSpell = spells[Random.Range(0, spells.Count)];
            playerMagicComponent.SetNewSpell(randomSpell);
            gameObject.SetActive(false);
        }
    }
}
