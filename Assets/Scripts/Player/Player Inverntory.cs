using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInverntory : MonoBehaviour
{
    public int numberOfCoins { get; private set; }
    public UnityEvent<PlayerInverntory> onCoinCollected;

    public void CoinCollected()
    {
        numberOfCoins++;
        onCoinCollected.Invoke(this);
    }

    
}
