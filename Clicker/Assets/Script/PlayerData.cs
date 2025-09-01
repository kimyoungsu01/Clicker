using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string MonsterName { get; private set; }
    public int MonsterHPCount { get; private set; }
    public int ATXCount { get; private set; }
    public int CTCCount { get; private set; }
    public int PointCount { get; private set; }
    public int GoldCount { get; private set; }

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(string name, int hp, int atx, int ctc, int Point, int gold)
    {
        MonsterName = name;
        MonsterHPCount = hp;
        ATXCount = atx;
        CTCCount = ctc;
        PointCount = Point;
        GoldCount = gold;
    }
}
