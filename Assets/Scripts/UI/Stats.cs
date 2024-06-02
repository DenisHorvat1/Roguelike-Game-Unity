using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI manaCost;
    public TextMeshProUGUI range;

    public void SetStats(float damageAmount, float fireRateAmount, float manaCostAmount, float rangeAmount)
    {
        damage.text = "Damange: " + damageAmount.ToString();
        fireRate.text = "Fire Rate: " + fireRateAmount.ToString();
        manaCost.text = "Mana Cost: " + manaCostAmount.ToString();
        range.text = "Range: " + rangeAmount.ToString();
    }
}
