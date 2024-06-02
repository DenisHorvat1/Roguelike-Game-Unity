using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;

    private float maxMana = 100f;
    private float currentMana;
    private float manaRechargeRate = 5f;

    private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    public Transform castPoint;

    private bool castingMagic = false;
    private bool isShooting = false;


    private void Awake()
    {
        currentMana = maxMana;
        timeBetweenCasts = spellToCast.SpellToCast.FireRate;
    }


    private void Update()
    {
        bool isSpellCastHeldDown = isShooting;
        bool hasEnoughMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;

        if (!castingMagic && isSpellCastHeldDown && hasEnoughMana) //shoot
        {
            castingMagic = true;
            currentMana -= spellToCast.SpellToCast.ManaCost;

            currentCastTimer = 0;
            CastSpell();
        }

        if (castingMagic) //cooldown
        {
            currentCastTimer += Time.deltaTime;
            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }

        if (currentMana < maxMana && !castingMagic)
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            if (currentMana > maxMana) currentMana = maxMana;
        }

    }
    public void Atack()
    {
        if(isShooting == false)
        {
            isShooting = true;
        }
    }

    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
        isShooting = false;
    }
}
