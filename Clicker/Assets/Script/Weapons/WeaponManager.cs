using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    public WeaponUI weaponUI;

    public WeaponData currentWeapon;
    public int upgradeLevel = 0;
    public int[] upgradeLevels = new int[5];
    public int index = 0;

    public WeaponInventoryUI weaponInventoryUI;

    public int CurrentAttack => currentWeapon.baseAtkDamage + upgradeLevels[index] * currentWeapon.atkDmgIncreasePerLevel;
    public float CurrentCritical => currentWeapon.baseCritical + upgradeLevels[index] * currentWeapon.criRateIncreasePerLevel;
    public int CurrentUpgradeCost => currentWeapon.baseUpgradeCost * (upgradeLevels[index]) * 2;
    //public int CurrentCriDmg => CurrentAttack * 2; // 크리티컬 데미지

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        WeaponData brokenSword = Resources.Load<WeaponData>("WeaponData/BrokenSword");
        EquipWeapon(brokenSword);
        weaponUI.Initialize();
    }

    public void EquipWeapon(WeaponData newWeapon)
    {
        currentWeapon = newWeapon;
        
    }

    public void UpgradeWeapon(WeaponData weaponData)
    {
        currentWeapon = weaponData;
    }

    //public int Damage()
    //{
    //    int baseDamage = CurrentAttack;

    //    // 크리티컬 발생 확률 체크
    //    if (Random.Range(0, 100) < CurrentCritical)
    //    {
    //        int critDamage = CurrentCriDmg;
    //        Debug.Log($"크리티컬 히트! {critDamage} 대미지");
    //        return critDamage;
    //    }
    //    else
    //    {
    //        Debug.Log($"일반 공격 {baseDamage} 대미지");
    //        return baseDamage;
    //    }
    //}
}
