using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;

    private List<WeaponData> weaponList = new List<WeaponData>();

    private void Start()
    {
        LoadAllWeapons();
        CreateInventoryUI();
    }

    // Resources 폴더에서 모든 무기 불러오기
    private void LoadAllWeapons()
    {
        WeaponData[] loadedWeapons = Resources.LoadAll<WeaponData>("WeaponData");
        weaponList.AddRange(loadedWeapons);
    }

    // UI 슬롯 동적 생성
    private void CreateInventoryUI()
    {
        foreach (WeaponData weapon in weaponList)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);

            // 슬롯 UI 구성 요소 가져오기
            //Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            //Text nameText = slot.transform.Find("Name").GetComponent<Text>();
            //Button buyButton = slot.transform.Find("BuyButton").GetComponent<Button>();

            // 무기 데이터 반영
            //icon.sprite = weapon.weaponIcon;
            //nameText.text = weapon.weaponName;

            // 버튼에 무기 연결
            // buyButton.onClick.AddListener(() => OnClickBuy(weapon));
        }
    }
}
