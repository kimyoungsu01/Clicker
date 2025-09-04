using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    public WeaponUI weaponUI;

    public WeaponData currentWeapon;
    public int upgradeLevel = 0;

    public int CurrentAttack => currentWeapon.baseAtkDamage + upgradeLevel * currentWeapon.atkDmgIncreasePerLevel;
    public float CurrentCritical => currentWeapon.baseCritical + upgradeLevel * currentWeapon.criRateIncreasePerLevel;
    public int CurrentUpgradeCost => currentWeapon.baseUpgradeCost * (upgradeLevel + 1) * 2;

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
        upgradeLevel = 0;
    }
}
