using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _quantityCoinsText;
    private int quantityCoins = 310;

    public readonly int CostPlayerHouse = 100;
    public readonly int CostCityHall = 100;
    public readonly int CostAcropolis = 100;
    public readonly int CostHouses = 5;

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
