using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI criticalDamageTitle;
    public TextMeshProUGUI criticalDamage;
    public TextMeshProUGUI criticalDamageValue;
    public TextMeshProUGUI autoAttackTitle;
    public TextMeshProUGUI autoAttack;
    public TextMeshProUGUI autoAttackValue;
    public TextMeshProUGUI getGoldTitle;
    public TextMeshProUGUI getGold;
    public TextMeshProUGUI getGoldValue;
    int criticalDamageCost = 10;
    int autoAttackCost = 10;
    int getGoldCost = 10;
    int stackPlus = 1;
    float criticalDamageUp = 50.0f;
    float autoAttackUp = 0.3f;
    float getGoldUp = 100.0f;
    void Start()
    {
        CriticalDamageUI();
        AutoAttackUI();
        GetGoldUI();
    }
    public void CriticalDamageUI()
    {
        criticalDamageTitle.text = "치명타 " + PlayerUpgrade.Instance.playerStat.criticalStack;
        criticalDamage.text = "치명타 데미지 +" + PlayerUpgrade.Instance.playerStat.criticalDamage;
        criticalDamageValue.text = criticalDamageCost.ToString();
    }

    public void AutoAttackUI()
    {
        autoAttackTitle.text = "자동 공격 " + PlayerUpgrade.Instance.playerStat.autoAttackStack;
        autoAttack.text = PlayerUpgrade.Instance.playerStat.autoAttackPerSec + "회/초";
        autoAttackValue.text = autoAttackCost.ToString(); 
    }

    public void GetGoldUI()
    {
        getGoldTitle.text = "골드 획득 " + PlayerUpgrade.Instance.playerStat.getGoldStack;
        getGold.text = "골드 획득량 +" + PlayerUpgrade.Instance.playerStat.getGoldPersent;
        getGoldValue.text = getGoldCost.ToString();
    }

    public void CriticalDamageBtn()
    {
        PlayerUpgrade.Instance.playerStat.criticalStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.criticalDamage += criticalDamageUp;
        criticalDamageCost += 10;
        CriticalDamageUI();
    }

    public void AutoAttackBtn()
    {
        PlayerUpgrade.Instance.playerStat.autoAttackStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.autoAttackPerSec += autoAttackUp;
        autoAttackCost += 10;
        AutoAttackUI();
    }

    public void GetGoldBtn()
    {
        PlayerUpgrade.Instance.playerStat.getGoldStack += stackPlus;
        PlayerUpgrade.Instance.playerStat.getGoldPersent += getGoldUp;
        getGoldCost += 10;
        GetGoldUI();
    }
    //버튼스크립트를 따로 만들어서 관리 
}
