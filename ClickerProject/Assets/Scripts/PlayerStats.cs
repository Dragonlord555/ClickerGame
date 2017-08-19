using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int
        coins = 0,
        currentXP = 0,
        currentLevel = 1,
        currentDamage = 10;

    public static float
        damageMultiplier = 1;

    public void CoinClick()
    {
        if(coins < 999999)
            coins++;
    }
}