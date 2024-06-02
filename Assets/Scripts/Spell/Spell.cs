using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellScriptableObject SpellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        //myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;


        Destroy(this.gameObject, SpellToCast.LifeTime);
    }


    private void Update()
    {
        if (SpellToCast.Speed > 0) transform.Translate(Vector3.forward * SpellToCast.Speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {

        //Aplly spell to waht we hit
        //apply hit particle effecs, sound eff.

        //Debug.Log(other.name);

        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(SpellToCast.DamageAmout);

            FindObjectOfType<AudioManager>().Play("EnemyDamage");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            
            PlayerHealthComponent playerHealth = other.GetComponent<PlayerHealthComponent>();
            playerHealth.TakeDamage(SpellToCast.DamageAmout);
            

            FindObjectOfType<AudioManager>().Play("PlayerDamage");

        }
        if (other.gameObject.CompareTag("Spell") || other.gameObject.CompareTag("Pick up"))
        {
            return;
            
        }

        Destroy(this.gameObject);
    }
}
