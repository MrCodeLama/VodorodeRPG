using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyManager : Singleton<EconomyManager>
{
    public TMP_Text goldText;
    public int currentGold = 0;

    public void UpdateCurrentCoins()
    {
        currentGold += 1;
    }

    private void Update()
    {
        goldText.text = currentGold.ToString("D3");
    }
}
