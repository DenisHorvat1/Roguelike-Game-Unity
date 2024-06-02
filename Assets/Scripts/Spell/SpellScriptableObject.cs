using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spell", menuName ="Spells")]
public class SpellScriptableObject : ScriptableObject
{
    public float ManaCost = 5f;
    public float LifeTime = 2f;
    public float Speed = 15f;
    public float DamageAmout = 10f;
    public float SpellRadius = 0.5f;
    public float FireRate = 2f;

    //status effect, Thumbnail, time between casts, magic elements
}
