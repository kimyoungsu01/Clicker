using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCost : MonoBehaviour
{
    public void goldCost(int amount)
    {
        int gold = GameManager.Instance.playerData.goldCount;

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
