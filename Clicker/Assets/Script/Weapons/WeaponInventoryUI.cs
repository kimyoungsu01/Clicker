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

    // Resources �������� ��� ���� �ҷ�����
    private void LoadAllWeapons()
    {
        WeaponData[] loadedWeapons = Resources.LoadAll<WeaponData>("WeaponData");
        weaponList.AddRange(loadedWeapons);
    }

    // UI ���� ���� ����
    private void CreateInventoryUI()
    {
        foreach (WeaponData weapon in weaponList)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);

            // ���� UI ���� ��� ��������
            //Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            //Text nameText = slot.transform.Find("Name").GetComponent<Text>();
            //Button buyButton = slot.transform.Find("BuyButton").GetComponent<Button>();

            // ���� ������ �ݿ�
            //icon.sprite = weapon.weaponIcon;
            //nameText.text = weapon.weaponName;

            // ��ư�� ���� ����
            // buyButton.onClick.AddListener(() => OnClickBuy(weapon));
        }
    }
}
