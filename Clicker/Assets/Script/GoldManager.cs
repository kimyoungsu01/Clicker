using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    // 골드 관리하는 메니저 따로 만들어 관리 
    public PlayerData PlayerData;
    // 플레이어 골드 추가
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
