using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void Awake()
    {
        PlayerUpgrade.Instance.statUpgradeUI = this;
    }
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
        criticalDamageValue.text = PlayerUpgrade.Instance.playerStat.criticalDamageCost.ToString();
    }

    public void AutoAttackUI()
    {
        autoAttackTitle.text = "자동 공격 " + PlayerUpgrade.Instance.playerStat.autoAttackStack;
        autoAttack.text = PlayerUpgrade.Instance.playerStat.autoAttackPerSec + "회/초";
        autoAttackValue.text = PlayerUpgrade.Instance.playerStat.autoAttackCost.ToString(); 
    }

    public void GetGoldUI()
    {
        getGoldTitle.text = "골드 획득 " + PlayerUpgrade.Instance.playerStat.getGoldStack;
        getGold.text = "골드 획득량 +" + PlayerUpgrade.Instance.playerStat.getGoldPersent;
        getGoldValue.text = PlayerUpgrade.Instance.playerStat.getGoldCost.ToString();
    }

    public void Refresh()
    {
        CriticalDamageUI();
        AutoAttackUI();
        GetGoldUI();
    }
}
