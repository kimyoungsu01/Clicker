using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image image;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI atkDmg;
    [SerializeField] private TextMeshProUGUI criRate;

    [Header("Purchase")]
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buyCost;

    [Header("Enhance")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradeCost;

    [Header("Equip")]
    [SerializeField] private Button equipButton;

    private WeaponData weaponData;

    // 무기 데이터 받아서 UI 초기화
    public void Setup(WeaponData data)
    {
        weaponData = data;

        // 무기 저장 데이터 불러오기 (없으면 새로 생성)
        var saveData = WeaponSaveManager.Instance.GetOrCreateWeapon(data.weaponID);

        int upgradeLevel = saveData.level;

        // UI 반영
        image.sprite = data.weaponIcon;
        name.text = $"{data.weaponName} Lv. {upgradeLevel}";
        atkDmg.text = $"공격력: {data.baseAtkDamage + upgradeLevel * data.atkDmgIncreasePerLevel}";
        criRate.text = $"{data.baseCritical + upgradeLevel * data.criRateIncreasePerLevel}%";

        buyCost.text = $"{data.buyCost}";
        upgradeCost.text = $"{data.baseUpgradeCost * (upgradeLevel + 1) * 2}";

        buyButton.onClick.AddListener(OnBuy);
        upgradeButton.onClick.AddListener(OnUpgrade);
        equipButton.onClick.AddListener(OnEquip);

        // 처음에는 구매 전 상태이므로 구매 버튼만 보이게

        if (saveData.isBuy == false)
        {
            buyButton.gameObject.SetActive(true);
            upgradeButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(false);
            upgradeButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);
        }

    }

    private void OnBuy()
    {
        int cost = weaponData.buyCost;

        if (CostManager.Instance.pointCount >= cost)
        {
            CostManager.Instance.PointSub(cost); // 포인트 차감
            CostManager.Instance.moneyScore.ReadPoint();
            Debug.Log($"{weaponData.weaponName} 구매 완료! 비용: {cost}");

            buyButton.gameObject.SetActive(false);
            upgradeButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);

            var saveData = WeaponSaveManager.Instance.GetOrCreateWeapon(weaponData.weaponID);
            saveData.isBuy = true;
            WeaponSaveManager.Instance.SaveWeapons();

            // 구매 후에는 강화 비용으로 표시 전환
            upgradeCost.text = weaponData.baseUpgradeCost.ToString();
        }

        else
        {
            Debug.Log("포인트 부족! 구매 실패");
            CostManager.Instance.OnZeroGold();
        }
    }

    private void OnUpgrade()
    {
        int index = weaponData.weaponID - 1;
        int upgradeLevel = WeaponManager.Instance.upgradeLevels[index];

        int cost = weaponData.baseUpgradeCost * (upgradeLevel) * 2;

        var saveData = WeaponSaveManager.Instance.GetOrCreateWeapon(weaponData.weaponID);

        if (CostManager.Instance.pointCount >= cost)
        {
            CostManager.Instance.PointSub(cost); // 포인트 차감
            CostManager.Instance.moneyScore.ReadPoint();

            WeaponManager.Instance.upgradeLevels[index]++;
            RefreshUI();

            
            saveData.level = WeaponManager.Instance.upgradeLevels[index];
            WeaponSaveManager.Instance.SaveWeapons();
            
            if (saveData.isEquipped == true)
            {
                WeaponUI.Instance.UpdateWeaponUI();
                Debug.Log("하이");
            }

            Debug.Log($"{weaponData.weaponName} 강화 완료! 현재 레벨: {saveData.level}");
        }
        else
        {
            Debug.Log("포인트 부족! 강화 실패");
            CostManager.Instance.OnZeroGold();
        }
    }

    private void OnEquip()
    {
        Debug.Log($"{weaponData.weaponName} 장착!");
        WeaponManager.Instance.EquipWeapon(weaponData);
        WeaponManager.Instance.index = weaponData.weaponID - 1;
        WeaponUI.Instance.UpdateWeaponUI();

        var saveData = WeaponSaveManager.Instance.GetOrCreateWeapon(weaponData.weaponID);

        foreach (var w in WeaponSaveManager.Instance.weaponSaveList)
            w.isEquipped = false; // 다른 무기는 해제

        saveData.isEquipped = true;
        WeaponSaveManager.Instance.SaveWeapons();
    }

    private void RefreshUI()
    {
        int index = weaponData.weaponID - 1;
        int upgradeLevel = WeaponManager.Instance.upgradeLevels[index];

        upgradeCost.text = (weaponData.baseUpgradeCost * (upgradeLevel + 1) * 2).ToString();
        image.sprite = weaponData.weaponIcon;
        name.text = $"{weaponData.weaponName} Lv. {upgradeLevel}";
        atkDmg.text = $"공격력: {weaponData.baseAtkDamage + upgradeLevel * weaponData.atkDmgIncreasePerLevel}";
        criRate.text = $"{weaponData.baseCritical + upgradeLevel * weaponData.criRateIncreasePerLevel}%";
    }
}
