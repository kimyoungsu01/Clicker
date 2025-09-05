using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBtn : MonoBehaviour
{
    float criticalDamageUp = 50.0f;
    float autoAttackUp = 0.3f;
    int getGoldUp = 100;
    int stackPlus = 1;
    StatUpgradeUI statUpgradeUI;

    void Awake()
    {
        statUpgradeUI = GetComponent<StatUpgradeUI>();
        PlayerUpgrade.Instance.upgradeBtn = this;
    }

    public void CriticalDamageBtn()
    {
        if (CostManager.Instance.goldCount >= PlayerUpgrade.Instance.playerStat.criticalDamageCost) 
        {
            PlayerUpgrade.Instance.playerStat.criticalStack += stackPlus;
            PlayerUpgrade.Instance.playerStat.criticalDamage += criticalDamageUp;
            CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.criticalDamageCost);
            PlayerUpgrade.Instance.playerStat.criticalDamageCost += 10;
            statUpgradeUI.CriticalDamageUI();
            PlayerUpgrade.Instance.SaveUserData();
            GameManager.Instance.SaveUserData();
        }
        else
        {
            CostManager.Instance.OnZeroGold();
        }
    }

    public void AutoAttackBtn()
    {
        if (CostManager.Instance.goldCount >= PlayerUpgrade.Instance.playerStat.autoAttackCost)
        {
            PlayerUpgrade.Instance.playerStat.autoAttackStack += stackPlus;
            PlayerUpgrade.Instance.playerStat.autoAttackPerSec += autoAttackUp;
            CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.autoAttackCost);
            PlayerUpgrade.Instance.playerStat.autoAttackCost += 10;
            statUpgradeUI.AutoAttackUI();
            PlayerUpgrade.Instance.SaveUserData();
            GameManager.Instance.SaveUserData();

            AutoAttack.Instance?.AutoClickBT();
        }
        else
        {
            CostManager.Instance.OnZeroGold();
        }        
    }

    public void GetGoldBtn()
    {
        if (CostManager.Instance.goldCount >= PlayerUpgrade.Instance.playerStat.getGoldCost)
        {
            PlayerUpgrade.Instance.playerStat.getGoldStack += stackPlus;
            PlayerUpgrade.Instance.playerStat.getGoldPersent += getGoldUp;
            CostManager.Instance.GoldSub(PlayerUpgrade.Instance.playerStat.getGoldCost);
            PlayerUpgrade.Instance.playerStat.getGoldCost += 10;
            statUpgradeUI.GetGoldUI();
            PlayerUpgrade.Instance.SaveUserData();
            GameManager.Instance.SaveUserData();
        }
        else
        {
            CostManager.Instance.OnZeroGold();
        }
    }

    public float SetGoldUp(float gold)
    {
        gold = gold+ (gold * PlayerUpgrade.Instance.playerStat.getGoldPersent / 100);
        return gold;
    }
}
