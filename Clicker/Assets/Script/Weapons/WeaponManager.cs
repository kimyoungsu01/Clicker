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
}
