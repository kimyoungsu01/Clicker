using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public int weaponID;
    public string weaponName;
    public Sprite weaponIcon;

    public int baseAtkDamage;     // 기본 공격력
    public int baseCritical;      // 기본 크리티컬 확률

    public int[] attackUpgradeTable;   // 각 강화 단계에서 공격력 증가량
    public int[] criticalUpgradeTable; // 각 강화 단계에서 크리티컬 증가량
}