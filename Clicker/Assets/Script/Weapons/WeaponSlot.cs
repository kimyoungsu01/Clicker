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

        image.sprite = data.weaponIcon;
        name.text = data.weaponName;
        atkDmg.text = $"공격력: {data.baseAtkDamage}";
        criRate.text = $"{data.baseCritical}%";

        buyCost.text = $"{data.buyCost}";

        upgradeCost.text = $"{data.baseUpgradeCost}";

        buyButton.onClick.AddListener(OnBuy);
        upgradeButton.onClick.AddListener(OnUpgrade);
        equipButton.onClick.AddListener(OnEquip);

        // 처음에는 구매 전 상태이므로 구매 버튼만 보이게
        buyButton.gameObject.SetActive(true);
        upgradeButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
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
        WeaponManager.Instance.UpgradeWeapon(weaponData);

        int cost = WeaponManager.Instance.CurrentUpgradeCost;

        if (CostManager.Instance.pointCount >= cost)
        {
            CostManager.Instance.PointSub(cost); // 포인트 차감
            CostManager.Instance.moneyScore.ReadPoint();
            WeaponManager.Instance.index = weaponData.weaponID - 1;
            WeaponManager.Instance.upgradeLevels[WeaponManager.Instance.index]++;

            Debug.Log($"{weaponData.weaponName} 강화 완료! 현재 데미지: {WeaponManager.Instance.CurrentAttack}");

            upgradeCost.text = WeaponManager.Instance.CurrentUpgradeCost.ToString();
            WeaponUI.Instance.UpdateWeaponUI();
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
        WeaponUI.Instance.UpdateWeaponUI();
    }
}
