using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    [Header("스테이지")]
    public int Stagenum;

    [Header("골드")]
    //public int Stagenum;

    [Header("업그레이드")]
    //public int Stagenum;

    [Header("장비장착")]
    public int Item;

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int num, string name, int cash, int balance)   
    {
        Stagenum = num;

    }
}
