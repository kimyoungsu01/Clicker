using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public static WeaponUI Instance;

    public TextMeshProUGUI weaponNameText; // 무기 이름 + Lv
    public Image weaponIcon;
    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI criticalRateText;
    public Button openInventory;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        openInventory.onClick.AddListener(() =>
        {
            //인벤토리 열기
        });
        UpdateWeaponUI();
    }

    public void UpdateWeaponUI()
    {
        if (WeaponManager.Instance.currentWeapon == null) return;

        WeaponData weapon = WeaponManager.Instance.currentWeapon;

        weaponIcon.sprite = weapon.weaponIcon;
        weaponNameText.text = $"{weapon.weaponName} Lv. {WeaponManager.Instance.upgradeLevel}";
        attackDamageText.text = $"공격력: {WeaponManager.Instance.CurrentAttack}";
        criticalRateText.text = $"치명타 확률: {WeaponManager.Instance.CurrentCritical}%";
    }
}
