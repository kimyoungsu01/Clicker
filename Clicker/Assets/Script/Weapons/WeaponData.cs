using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public int weaponID;
    public string weaponName;
    public Sprite weaponIcon;

    public int baseAtkDamage;     // 기본 공격력
    public int baseCritical;      // 기본 크리티컬 확률

    public int atkDmgIncreasePerLevel;     // 공격력 강화당 증가량
    public int criRateIncreasePerLevel;    // 크리티컬 강화당 증가량
    
    public int buyCost;               // 무기 구매 비용
    public int baseUpgradeCost;       // 처음 강화 비용
}