using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;

    private float maxMana = 100f;
    private float currentMana;
    private float manaRechargeRate = 10f;

    private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    public Transform castPoint;

    private bool castingMagic = false;

    private PlayerControls playerControls;

    public HealthBar manaBar;
    public Stats stats;

    private void Awake()
    {
        playerControls = new PlayerControls();
        currentMana = maxMana;
        manaBar.SetMaxHealth(maxMana);
        timeBetweenCasts = spellToCast.SpellToCast.FireRate;

        stats.SetStats(spellToCast.SpellToCast.DamageAmout, spellToCast.SpellToCast.FireRate, spellToCast.SpellToCast.ManaCost, spellToCast.SpellToCast.Speed * spellToCast.SpellToCast.LifeTime);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        bool isSpellCastHeldDown = playerControls.Controls.SpellCast.ReadValue<float>() > 0.1;
        bool hasEnoughMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;

        if (!castingMagic && isSpellCastHeldDown && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= spellToCast.SpellToCast.ManaCost;
            manaBar.SetHealth(currentMana);

            currentCastTimer = 0;
            CastSpell();
        }

        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            if(currentCastTimer> timeBetweenCasts) castingMagic = false;
        }

        if(currentMana < maxMana && !castingMagic )
        {
            currentMana += manaRechargeRate * Time.deltaTime;
            manaBar.SetHealth(currentMana);
            if (currentMana > maxMana) currentMana = maxMana;
        }

    }

    void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }

    public void AddMana(float manaAmount)
    {
        currentMana += manaAmount;
        manaBar.SetHealth(currentMana);

        if(currentMana > maxMana)
        {
            currentMana = maxMana;
            manaBar.SetHealth(currentMana);
        }
    }

    public void SetNewSpell(Spell newSpell)
    {

        spellToCast = newSpell;

        timeBetweenCasts = spellToCast.SpellToCast.FireRate;

        stats.SetStats(spellToCast.SpellToCast.DamageAmout, spellToCast.SpellToCast.FireRate, spellToCast.SpellToCast.ManaCost, spellToCast.SpellToCast.Speed * spellToCast.SpellToCast.LifeTime);
    }
}
