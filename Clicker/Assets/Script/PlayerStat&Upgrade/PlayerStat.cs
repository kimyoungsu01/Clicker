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
    public PlayerStat(int criticalStack, float criticalDamage, int autoAttackStack, float autoAttackPerSec, int getGoldStack, float getGoldPersent)
    {
        this.criticalStack = criticalStack;
        this.criticalDamage = criticalDamage;
        this.autoAttackStack = autoAttackStack;
        this.autoAttackPerSec = autoAttackPerSec;
        this.getGoldStack = getGoldStack;
        this.getGoldPersent = getGoldPersent;
    }
}
