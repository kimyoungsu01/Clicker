using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    // ��� �����ϴ� �޴��� ���� ����� ���� 
    public PlayerData PlayerData;
    // �÷��̾� ��� �߰�
    public void Deposits(int amount)
    {
        GameManager.Instance.PlayerData();
        int gold = PlayerData.goldCount;

        if (gold >= amount)
        {
            gold -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            GameManager.Instance.sceneLoader.OnZeroGold();
        }
    }
}
