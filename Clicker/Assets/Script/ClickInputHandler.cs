using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInputHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Ŭ�� ����
        {

            Debug.Log("Valid Click!");

            // 1) UI ������ üũ
            // 2) ���� ���� üũ (Paused�� ����)
            // 3) ���� ��� �� "��ȿ Ŭ�� �߻�" ��ȣ ����
        }
    }
}
