using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private Button backButton;

    public List<WeaponData> weaponList = new List<WeaponData>();  // 데이터를 원하는 순서대로 동적 생성하기 위해 public 설정 후 Inspector 창에서 직접 데이터 넣어줌.

    private void Start()
    {
        CreateInventoryUI();

        backButton.onClick.AddListener(BackButton);
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
