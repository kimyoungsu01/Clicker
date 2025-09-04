using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBtn : MonoBehaviour
{
    float criticalDamageUp = 50.0f;
    float autoAttackUp = 0.3f;
    float getGoldUp = 100.0f;
    int stackPlus = 1;
    StatUpgradeUI statUpgradeUI;

    void Awake()
    {
        statUpgradeUI = GetComponent<StatUpgradeUI>();
    }

    public void CriticalDamageBtn()
    {
        PlayerUpgrade.Instance.playerStat.criticalStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.criticalDamage += criticalDamageUp;
        CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.criticalDamageCost);
        PlayerUpgrade.Instance.playerStat.criticalDamageCost += 10;
        statUpgradeUI.CriticalDamageUI();
    }

    public void AutoAttackBtn()
    {
        PlayerUpgrade.Instance.playerStat.autoAttackStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.autoAttackPerSec += autoAttackUp;
        CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.autoAttackCost);
        PlayerUpgrade.Instance.playerStat.autoAttackCost += 10;
        statUpgradeUI.AutoAttackUI();
    }

    public void GetGoldBtn()
    {
        PlayerUpgrade.Instance.playerStat.getGoldStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.getGoldPersent += getGoldUp;
        CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.getGoldCost);
        PlayerUpgrade.Instance.playerStat.getGoldCost += 10;
        statUpgradeUI.GetGoldUI();
    }
}
