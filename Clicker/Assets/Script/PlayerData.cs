using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int stageNum { get; private set; }
    public string monsterName { get; private set; }
    public int monsterHPCount { get; private set; }
    public int atxCount { get; private set; }
    public int ctcCount { get; private set; }
    public int pointCount { get; private set; }
    public int goldCount { get; private set; }

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int num, string name, int hp, int atx, int ctc, int Point, int gold)
    {
        stageNum = num;
        monsterName = name;
        monsterHPCount = hp;
        atxCount = atx;
        ctcCount = ctc;
        pointCount = Point; // 소지 포인트
        goldCount = gold; // 소지 골드
    }

    // 플레이어 골드 추가
    public void Deposits(int amount)
    {
        if (goldCount >= amount)
        {
            goldCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else 
        {
            GameManager.Instance.sceneLoader.OnZeroGold();
        }
    }
}
