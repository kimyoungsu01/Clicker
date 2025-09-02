using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    public WeaponData currentWeapon;
    public int upgradeLevel = 0;

    public int CurrentAttack => currentWeapon.baseAtkDamage + upgradeLevel * currentWeapon.atkDmgIncreasePerLevel;
    public float CurrentCritical => currentWeapon.baseCritical + upgradeLevel * currentWeapon.criRateIncreasePerLevel;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        WeaponData woodSword = Resources.Load<WeaponData>("WeaponData/WoodSword");
        EquipWeapon(woodSword);
    }

    public void EquipWeapon(WeaponData newWeapon)
    {
        currentWeapon = newWeapon;
        upgradeLevel = 0;
        WeaponUI.Instance.UpdateWeaponUI();
    }
}
