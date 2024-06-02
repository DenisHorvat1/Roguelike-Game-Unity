using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinText(PlayerInverntory playerInverntory)
    {
        coinText.text = playerInverntory.numberOfCoins.ToString();

    }
}
