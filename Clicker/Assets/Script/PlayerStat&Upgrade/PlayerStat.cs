using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerStat : MonoBehaviour
{
    public int criticalStack = 0;
    public float criticalDamage = 0;

    public int autoAttackStack = 0;
    public float autoAttackPerSec = 0;

    public int getGoldStack = 0;
    public float getGoldPersent = 0;

    public int criticalDamageCost = 10;

    public int autoAttackCost = 10;

    public int getGoldCost = 10;

    public float currentGoldUp;

    public PlayerStat(int criticalStack, float criticalDamage, int autoAttackStack, float autoAttackPerSec, int getGoldStack, int getGoldPersent, int criticalDamageCost, int autoAttackCost, int getGoldCost, float currentGoldUp)
    {
        this.criticalStack = criticalStack;
        this.criticalDamage = criticalDamage;

        this.autoAttackStack = autoAttackStack;
        this.autoAttackPerSec = autoAttackPerSec;

        this.getGoldStack = getGoldStack;
        this.getGoldPersent = getGoldPersent;

        this.criticalDamageCost = criticalDamageCost;

        this.autoAttackCost = autoAttackCost;

        this.getGoldCost = getGoldCost;

        this.currentGoldUp = currentGoldUp;
    }
}
