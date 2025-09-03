using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private Button backButton;

    private List<WeaponData> weaponList = new List<WeaponData>();

    private void Start()
    {
        LoadAllWeapons();
        CreateInventoryUI();

        backButton.onClick.AddListener(BackButton);
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
            WeaponSlot slotScript = slot.GetComponent<WeaponSlot>();
            slotScript.Setup(weapon);
        }
    }

    public void BackButton()
    {
        gameObject.SetActive(false);
        EnemyManager.Instance.TurnonUI();
    }
}
