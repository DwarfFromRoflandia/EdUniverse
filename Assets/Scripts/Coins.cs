using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _quantityCoinsText;
    private int quantityCoins = 100;

    public void Initialize()
    {
        _quantityCoinsText.text = quantityCoins.ToString();
    }

    public int QuantityCoins
    {
        get { return quantityCoins; }
        set 
        {
            if (value >= 0)
            {
                quantityCoins = value;
                _quantityCoinsText.text = quantityCoins.ToString();
            }             
        }
    }

}
