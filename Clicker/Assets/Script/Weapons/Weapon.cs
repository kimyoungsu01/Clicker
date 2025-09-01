using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public int upgradeLevel = 0;


    // 현재 공격력, 크리 확률 = 기본 + (강화단계 * 증가량)
    public int CurrentAttack => data.baseAtkDamage + (upgradeLevel * data.atkDmgIncreasePerLevel);  // 공격력 증가량
    public int CurrentCritical => data.baseCritical + (upgradeLevel * data.criRateIncreasePerLevel); // 크리 확률 증가량

    public void Upgrade()
    {
        upgradeLevel++;
    }
}
