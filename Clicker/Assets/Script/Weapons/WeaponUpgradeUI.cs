using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeUI : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Weapon weapon; // 강화 대상 무기 (Inspector에서 연결)

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgrade);
    }

    private void OnUpgrade()
    {
        weapon.Upgrade(); // 무기 강화 실행
        Debug.Log($"강화됨! 공격력: {weapon.CurrentAttack}, 크리티컬: {weapon.CurrentCritical}");
    }
}
