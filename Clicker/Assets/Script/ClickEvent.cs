using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public bool isPaused = false;
    public bool assumeMonsterPresent = true; // ���͸� ����


    public UnityEvent onAttack; // �׽�Ʈ����
    // public UnityEvent<Vector2> onClickValidated; // ��ȿ Ŭ�� ��ǥ ����

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        { 
            return; 
        }

        if (isPaused)
        {
            return;
        }

        if (EventSystem.current && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!assumeMonsterPresent)
        {
            return;        
        }

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // onClickValidated?.Invoke(worldPos);

        Debug.Log("Ŭ���Ͽ� �������� �־���");
        onAttack?.Invoke(); // �׽�Ʈ��

    }





}
