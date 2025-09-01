using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public int weaponID;
    public string weaponName;
    public Sprite weaponIcon;

    public int baseAtkDamage;     // �⺻ ���ݷ�
    public int baseCritical;      // �⺻ ũ��Ƽ�� Ȯ��

    public int[] attackUpgradeTable;   // �� ��ȭ �ܰ迡�� ���ݷ� ������
    public int[] criticalUpgradeTable; // �� ��ȭ �ܰ迡�� ũ��Ƽ�� ������
}