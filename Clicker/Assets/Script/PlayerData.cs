using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    [Header("��������")]
    public int Stagenum;

    [Header("���")]
    //public int Stagenum;

    [Header("���׷��̵�")]
    //public int Stagenum;

    [Header("�������")]
    public int Item;

    // �����ڶ�? ����: ��ȯŸ��x, Ŭ������ �̸��� �Ȱ���,
    // �Ű������� �־ �ǰ� ��� �ȴ�,
    // �������� �ɹ������� �Ű������� ��밡��
    public PlayerData(int num, string name, int cash, int balance)   
    {
        Stagenum = num;

    }
}
